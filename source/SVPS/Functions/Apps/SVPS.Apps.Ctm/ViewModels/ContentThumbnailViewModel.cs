using SVPS.Apps.Common;
using SVPS.Core.Attributes;
using SVPS.Core.Presentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPS.Apps.Ctm.ViewModels
{
	[PerspectiveFrame("ContentThumbnailDocument")]
	public class ContentThumbnailViewModel : AppsDocumentViewModelBase
	{
		public ContentThumbnailViewModel()
		{
			this.InputMetaViewExtRibbonMenuVisibleFlag = true;
		}

		public override void OnActiveViewModel(string perspectiveName, object param)
		{
		
		}

		public override void OnDeActiveViewModel(string perspectiveName)
		{
		
		}
	}
}
