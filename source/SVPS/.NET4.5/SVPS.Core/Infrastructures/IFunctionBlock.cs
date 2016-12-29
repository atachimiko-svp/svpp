using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPS.Core.Infrastructures
{
	public interface IFunctionBlock
	{

		#region Public メソッド

		void OnInitializeFunction(object sender, EventArgs args);

		#endregion Public メソッド
	}
}
