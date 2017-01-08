using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPS.Apps.Common
{
	public interface IAppPerspectiveViewModel
	{

		#region Public メソッド

		void StartPerspective(PerspectiveNames perspectiveName, object param = null);

		#endregion Public メソッド
	}
}
