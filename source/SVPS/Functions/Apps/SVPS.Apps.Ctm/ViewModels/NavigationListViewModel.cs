using SVPS.Core.Attributes;
using SVPS.Core.Presentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPS.Apps.Ctm.ViewModels
{
	[PerspectiveFrame("NavigationListPane")]
	public class NavigationListViewModel : PaneViewModelBase
	{

		#region Public メソッド

		public override void OnActiveViewModel(string perspectiveName, object param)
		{
			
		}

		public override void OnDeActiveViewModel(string perspectiveName)
		{

		}

		#endregion Public メソッド
	}
}
