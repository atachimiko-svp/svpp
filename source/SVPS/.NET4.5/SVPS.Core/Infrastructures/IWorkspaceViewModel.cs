using Livet.Messaging;
using SVPS.Core.Presentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPS.Core.Infrastructures
{
	public interface IWorkspaceViewModel
	{


		#region Public プロパティ

		InteractionMessenger Messenger { get; }

		#endregion Public プロパティ


		#region Public メソッド

		void AttachViewModel(string position, PerspectiveViewModelBase perspectiveVm);

		#endregion Public メソッド
	}
}
