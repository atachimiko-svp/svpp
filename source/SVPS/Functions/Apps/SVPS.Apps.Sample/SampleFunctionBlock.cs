using SVPS.Apps.Common;
using SVPS.Core;
using SVPS.Core.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPS.Apps.Sample
{
	/// <summary>
	/// Sample機能ブロック
	/// </summary>
	public class SampleFunctionBlock : IFunctionBlock
	{

		#region Private フィールド

		PerspectiveViewModelHandle m_hpSampleViewModel;
		
		PerspectiveViewModelHandle m_LeftDockPanelViewModel;
		PerspectiveViewModelHandle m_RightDockPanelViewModel;

		#endregion Private フィールド


		#region Public メソッド

		public void OnInitializeFunction(object sender, EventArgs args)
		{
			m_hpSampleViewModel = ApplicationContext.Ux.AddPerspectiveViewModel(new SampleViewModel());

			// ViewModelは、UXで管理しアプリケーションドメインではハンドルを操作する
			// アプリケーションドメインではハンドルをグローバル変数で管理する。
			if (!AppPerspectiveHolder.InputMetaControlViewModelHandle.HasValue)
				AppPerspectiveHolder.InputMetaControlViewModelHandle = ApplicationContext.Ux.AddPerspectiveViewModel(new ManualMetaInputSampleViewModel());

			// 下記の2つは、デバッグ用のViewModelで、後で削除するのでAppPerspectiveHolderで管理しない。
			m_LeftDockPanelViewModel = ApplicationContext.Ux.AddPerspectiveViewModel(new LeftDockPanelViewModel());
			m_RightDockPanelViewModel = ApplicationContext.Ux.AddPerspectiveViewModel(new RightDockPanelViewModel());

			ApplicationContext.Ux.SetPerspectiveViewModel(
				PerspectiveNames.ContentList_Thumbnail.ToString(),
				Core.ViewpositionNames.Document,
				m_hpSampleViewModel);

			ApplicationContext.Ux.SetPerspectiveViewModel(
				PerspectiveNames.Seiri.ToString(),
				Core.ViewpositionNames.Document,
				m_hpSampleViewModel);

			ApplicationContext.Ux.SetPerspectiveViewModel(
				PerspectiveNames.Seiri.ToString(),
				Core.ViewpositionNames.DockKeel,
				AppPerspectiveHolder.InputMetaControlViewModelHandle.Value);

			ApplicationContext.Ux.SetPerspectiveViewModel(
				PerspectiveNames.Seiri.ToString(),
				Core.ViewpositionNames.DockLeft,
				m_LeftDockPanelViewModel);

			ApplicationContext.Ux.SetPerspectiveViewModel(
				PerspectiveNames.Seiri.ToString(),
				Core.ViewpositionNames.DockRight,
				m_RightDockPanelViewModel);
		}

		#endregion Public メソッド
	}
}
