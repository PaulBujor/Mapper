using System;
using System.Collections.Generic;
using System.Text;

namespace DataServer.Models
{
	public class Report<T>
	{
		public long reportId { get; set; }
		public T reportedItem { get; set; }
		public string reportedClass { get; set; }
		public bool resolved { get; set; }
		public string category { get; set; }
		public string description { get; set; }

		public Report()
		{
		}
	}
}
