using log4net;
using SVPS.Core.Presentations;
using Sakura.Data.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPS.Data.ViewModels
{
	public class SearchViewModel : PaneViewModelBase
	{

		#region フィールド

		static ILog LOG = LogManager.GetLogger(typeof(SearchViewModel));

		#endregion フィールド


		#region メソッド

		public override void OnActiveViewModel(string perspectiveName, object param)
		{
			LOG.DebugFormat("Execute {0}", this.CurrentPerspectiveName);
		}

		public override void OnDeActiveViewModel(string perspectiveName)
		{
			LOG.DebugFormat("Execute {0}", this.CurrentPerspectiveName);
		}

		#endregion メソッド

	}
}
