using SVPCONT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPCONT.Request
{
	public class RequestTagCrud
	{

		#region プロパティ

		public CrudType Crud { get; set; }

		public Tag Target { get; set; }

		#endregion プロパティ
	}
}
