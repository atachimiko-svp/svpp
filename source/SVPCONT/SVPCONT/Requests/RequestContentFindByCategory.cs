using SVPCONT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPCONT.Request
{
	public class RequestContentFindByCategory
	{


		#region プロパティ

		public Category Category { get; set; }

		public bool EnableThumbnailFlag { get; set; }

		#endregion プロパティ

	}
}
