using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Models
{
	public class Review
	{
		public long id { get; set; }
		public int rating { get; set; }
		public string comment { get; set; }
		public UserData addedBy { get; set; }
	}
}
