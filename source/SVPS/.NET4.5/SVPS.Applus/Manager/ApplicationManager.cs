using SVPS.Core.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPS.Applus.Manager
{
	public delegate void InitializeFunctionEventHandler(object sender, EventArgs args);

	public class ApplicationManager : IApplicationManager
	{


		#region Public イベント

		public event InitializeFunctionEventHandler InitializeFunction;

		#endregion Public イベント


		#region Public メソッド

		public void RaiseInitializeFunction()
		{
			if (InitializeFunction != null) InitializeFunction(this, new EventArgs());
		}

		public void RegisterFunctionBlock(IFunctionBlock functionBlock)
		{
			InitializeFunction += functionBlock.OnInitializeFunction;
		}

		#endregion Public メソッド
	}
}
