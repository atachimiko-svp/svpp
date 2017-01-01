using SVPS.Core.Presentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPS.Core.Infrastructures
{
	public delegate void ActiveViewModelEventHandler(ActiveViewModelEventArgs args);

	public delegate void DeActiveViewModelEventHandler(string perspectiveName);

	/// <summary>
	/// 
	/// </summary>
	public interface IUxManager
	{


		#region Public イベント

		event ActiveViewModelEventHandler OnActiveViewModel;

		event DeActiveViewModelEventHandler OnDeActiveViewModel;

		#endregion Public イベント


		#region Public メソッド

		PerspectiveViewModelHandle AddPerspectiveViewModel(PerspectiveViewModelBase pd);

		void ChangePerspective(string perspectiveName, object param = null);

		PerspectiveViewModelBase GetPerspectiveViewModel(PerspectiveViewModelHandle hpvm);

		bool SetPerspectiveViewModel(PerspectiveNames perspectiveName, ViewpositionNames position, PerspectiveViewModelHandle handle);

		#endregion Public メソッド

	}

	public struct PerspectiveViewModelHandle
	{


		#region Public コンストラクタ

		public PerspectiveViewModelHandle(int handleId)
		{
			this.Handle = handleId;
		}

		#endregion Public コンストラクタ


		#region Public プロパティ

		public int Handle { get; }

		#endregion Public プロパティ

	}
	public class ActiveViewModelEventArgs : EventArgs
	{


		#region Public プロパティ

		public object Param { get; set; }
		public string PerspectiveName { get; set; }

		#endregion Public プロパティ

	}
}
