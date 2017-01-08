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
	[PerspectiveFrame("InputMenuControlPane")]
	public class InputMetaControlViewModel : AppsPaneViewModelBase
	{

		#region Public コンストラクタ

		public InputMetaControlViewModel()
		{
		
		}

		#endregion Public コンストラクタ


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
