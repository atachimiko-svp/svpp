﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPCONT.Domain
{
	public class Tag
	{

		#region プロパティ

		public string Comment { get; set; }
		public DateTime? CreateDate { get; set; }
		public long Id { get; set; }
		public DateTime? LastUpDate { get; set; }
		public string Name { get; set; }

		#endregion プロパティ
	}
}
