using System;
using System.Collections.Generic;
using System.Text;

namespace DataServer.Models
{
	class User
	{
		public string username { get; set; }
		public string password { get; set; }
		public int auth { get; set; }
		//0 banned
		//1 regular user
		//2 moderator
		//3 admin
	}
}
