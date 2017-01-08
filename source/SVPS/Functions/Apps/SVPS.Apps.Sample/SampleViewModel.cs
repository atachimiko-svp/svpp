using SVPS.Apps.Common;
using SVPS.Core.Attributes;
using SVPS.Core.Presentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPS.Apps.Sample
{
	[FunctionBlock]
	public class SampleViewModel : AppsDocumentViewModelBase
	{

		#region Private フィールド

		private bool m_SampleContextualMenuVisibilityFlag;

		#endregion Private フィールド


		#region Public コンストラクタ

		public SampleViewModel()
		{
			var pd = this.PropertyData.AddPropertyDataSet("プロジェクトカーズ");
			pd.AddProperty("OS", "Windows 10");
			pd.AddProperty("CPU", "Core i5");
			pd.AddProperty("メモリー", "1.5G以上");
		}

		#endregion Public コンストラクタ


		#region Public プロパティ

		public bool SampleContextualMenuVisibilityFlag
		{
			get { return m_SampleContextualMenuVisibilityFlag; }
			set
			{
				m_SampleContextualMenuVisibilityFlag = value;
				RaisePropertyChanged();
			}
		}

		#endregion Public プロパティ


		#region Public メソッド

		public override void OnActiveViewModel(string perspectiveName, object param)
		{
			SampleContextualMenuVisibilityFlag = true;
			this.RBulgeVisibilityFlag = true;
		}

		public override void OnDeActiveViewModel(string perspectiveName)
		{

		}

		#endregion Public メソッド
	}
}
