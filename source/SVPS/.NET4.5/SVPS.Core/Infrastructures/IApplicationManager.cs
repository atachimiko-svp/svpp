using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPS.Core.Infrastructures
{
	public interface IApplicationManager
	{

		#region Public メソッド

		void RegisterFunctionBlock(IFunctionBlock functionBlock);

		#endregion Public メソッド
	}
}
