using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPS.Core.Presentations
{
	public abstract class PaneViewModelBase : PerspectiveViewModelBase
	{


		#region Private フィールド

		private bool _IsOpen = true;

		private bool _VisibilityFlag = true;

		#endregion Private フィールド


		#region Public プロパティ

		public bool IsOpen
		{
			get { return _IsOpen; }
			set
			{
				_IsOpen = value;
				RaisePropertyChanged();
			}
		}

		public bool VisibilityFlag
		{
			get { return _VisibilityFlag; }
			set
			{
				_VisibilityFlag = value;
				RaisePropertyChanged();
			}
		}

		#endregion Public プロパティ

	}
}
