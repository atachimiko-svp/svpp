using SVPS.Core;
using SVPS.Core.Presentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPS.Apps.Common
{
	public abstract class AppsPaneViewModelBase : PaneViewModelBase, IAppPerspectiveViewModel
	{

		#region Public メソッド

		public void StartPerspective(PerspectiveNames perspectiveName, object param = null)
		{
			var textName = Enum.GetName(typeof(PerspectiveNames), perspectiveName);
			ApplicationContext.Ux.ChangePerspective(textName, param);
		}

		#endregion Public メソッド

	}
}
