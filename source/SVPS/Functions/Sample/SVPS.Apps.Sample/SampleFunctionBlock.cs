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
		PerspectiveViewModelHandle m_hpManualMetaInputSampleViewModel;

		#endregion Private フィールド


		#region Public メソッド

		public void OnInitializeFunction(object sender, EventArgs args)
		{
			m_hpSampleViewModel = ApplicationContext.Ux.AddPerspectiveViewModel(new SampleViewModel());
			m_hpManualMetaInputSampleViewModel = ApplicationContext.Ux.AddPerspectiveViewModel(new ManualMetaInputSampleViewModel());

			ApplicationContext.Ux.SetPerspectiveViewModel(
				Core.PerspectiveNames.ContentList_Thumbnail,
				Core.ViewpositionNames.Document,
				m_hpSampleViewModel);

			ApplicationContext.Ux.SetPerspectiveViewModel(
				Core.PerspectiveNames.Seiri,
				Core.ViewpositionNames.DockBottom,
				m_hpManualMetaInputSampleViewModel);
		}

		#endregion Public メソッド
	}
}
