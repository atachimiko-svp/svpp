using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPS.Core.Attributes
{
	[AttributeUsage(AttributeTargets.Class)]
	public class PerspectiveFrameAttribute : Attribute
	{

		#region Public コンストラクタ

		public PerspectiveFrameAttribute(string elementName)
		{
			this.ElementName = elementName;
		}

		#endregion Public コンストラクタ


		#region Public プロパティ

		public string ElementName { get; set; }

		#endregion Public プロパティ
	}
}
