using System;

namespace DataServer.Models
{
	[Serializable]
	public class UserData
	{
		public long userId { get; set; }
		public string username { get; set; }

		public UserData() { }
	}
}