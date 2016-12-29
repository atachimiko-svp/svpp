using SVPCONT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPCONT.Request
{
	public class RequestWorkspaceCrud
	{
		#region プロパティ

		public CrudType Crud { get; set; }

		public Workspace Target { get; set; }

		#endregion プロパティ
	}
}
