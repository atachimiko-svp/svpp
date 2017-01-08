using SVPS.Core;
using SVPS.Core.Infrastructures;
using SVPS.Core.Presentations;
using SVPS.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPS.Applus.Manager
{

	public class UxManager : IUxManager
	{


		#region Private フィールド

		Perspective _CurrentPerspective = null;

		List<Perspective> _PerspectiveList = new List<Perspective>();

		List<PerspectiveViewModelBase> _ViewModels = new List<PerspectiveViewModelBase>();

		#endregion Private フィールド


		#region Public コンストラクタ

		public UxManager()
		{

		}

		#endregion Public コンストラクタ


		#region Public イベント

		public event ActiveViewModelEventHandler OnActiveViewModel;

		public event DeActiveViewModelEventHandler OnDeActiveViewModel;

		#endregion Public イベント


		#region Public メソッド

		public PerspectiveViewModelHandle AddPerspectiveViewModel(PerspectiveViewModelBase pd)
		{
			_ViewModels.Add(pd);
			return new PerspectiveViewModelHandle(_ViewModels.Count - 1);
		}

		public void ChangePerspective(string perspectiveName, object param = null)
		{
			// Guard
			var pers = GetPerspective(perspectiveName);
			if (pers == null)
				throw new ApplicationException();

			if (OnDeActiveViewModel != null)
				OnDeActiveViewModel(perspectiveName);

			// イベントハンドラ解除
			if (_CurrentPerspective != null)
			{

				foreach (var pp in _CurrentPerspective.PerspectiveVmDict)
				{
					if (pp.Value != null)
					{
						OnActiveViewModel -= pp.Value.ActiveViewModel;
						OnDeActiveViewModel -= pp.Value.DeActiveViewModel;
					}
				}
			}

			_CurrentPerspective = pers;

			Dictionary<string, bool> dictSetAs = new Dictionary<string, bool>();
			Array.ForEach(Enum.GetNames(typeof(ViewpositionNames)), (prop) => dictSetAs.Add(prop, false));

			foreach (var pp in pers.PerspectiveVmDict)
			{

				if (pp.Value != null)
				{
					OnActiveViewModel += pp.Value.ActiveViewModel;
					OnDeActiveViewModel += pp.Value.DeActiveViewModel;
				}

				ApplicationContext.Workspace.AttachViewModel(pp.Key, pp.Value);
				dictSetAs[pp.Key] = true;
			}

			var rfalse = from u in dictSetAs
						 where u.Value == false
						 select u.Key;
			Array.ForEach(rfalse.ToArray(), prop => ApplicationContext.Workspace.AttachViewModel(prop, null));

			if (OnActiveViewModel != null)
				OnActiveViewModel(new ActiveViewModelEventArgs
				{
					PerspectiveName = perspectiveName,
					Param = param
				});
		}

		public PerspectiveViewModelBase GetPerspectiveViewModel(PerspectiveViewModelHandle handle)
		{
			return _ViewModels[handle.Handle];
		}

		/// <summary>
		/// パースペクティブへ表示情報を設定する
		/// </summary>
		/// <param name="perspectiveName">パースペクティブ名</param>
		/// <param name="position">表示位置名</param>
		/// <param name="handle">ビューと表示情報</param>
		/// <returns></returns>
		public bool SetPerspectiveViewModel(string perspectiveName, ViewpositionNames position, PerspectiveViewModelHandle handle)
		{
			var pn = perspectiveName;
			var vpn = Enum.GetName(typeof(ViewpositionNames), position);

			var r = from u in _PerspectiveList
					where u.PerspectiveName == pn
					select u;
			var perspective = r.FirstOrDefault();

			var pane = GetPerspectiveViewModel(handle);
			if (pane == null) return false;

			if (perspective == null)
			{
				perspective = new Perspective(pn);
				_PerspectiveList.Add(perspective);
			}

			perspective.PerspectiveVmDict[vpn] = pane;

			return true;
		}

		#endregion Public メソッド


		#region Private メソッド

		Perspective GetPerspective(string perspectiveName)
		{
			var r = from v in _PerspectiveList
					where v.PerspectiveName == perspectiveName
					select v;
			return r.FirstOrDefault();
		}

		#endregion Private メソッド
	}
}
