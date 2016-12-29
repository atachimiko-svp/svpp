using SVPCONT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPCONT.Response
{
	public class ResponseWorkspaceLoadList : ResponseBase
	{
		#region プロパティ

		public IList<Workspace> Datas { get; set; }

		#endregion プロパティ
	}
}
