using SVPCONT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPCONT.Request
{
	public class RequestCategoryCrud
	{

		#region プロパティ

		public CrudType Crud { get; set; }

		public Category Target { get; set; }

		#endregion プロパティ
	}
}
