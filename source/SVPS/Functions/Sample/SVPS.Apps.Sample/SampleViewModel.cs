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
	public class SampleViewModel : SDocumentViewModelBase
	{
		private bool m_SampleContextualMenuVisibilityFlag;

		public bool SampleContextualMenuVisibilityFlag
		{
			get { return m_SampleContextualMenuVisibilityFlag; }
			set
			{
				m_SampleContextualMenuVisibilityFlag = value;
				RaisePropertyChanged();
			}
		}

		public override void OnActiveViewModel(string perspectiveName, object param)
		{
			SampleContextualMenuVisibilityFlag = true;
		}

		public override void OnDeActiveViewModel(string perspectiveName)
		{
			
		}
	}
}
