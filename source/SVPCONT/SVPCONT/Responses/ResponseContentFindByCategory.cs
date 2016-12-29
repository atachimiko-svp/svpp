using SVPCONT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPCONT.Response
{
	public class ResponseContentFindByCategory : ResponseBase
	{
		#region プロパティ

		public IList<Content> Datas { get; set; }

		#endregion プロパティ
	}
}
