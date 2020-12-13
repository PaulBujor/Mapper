using System;

namespace Client.Models
{
	[Serializable]
	public class UserData
	{
		public long userId { get; set; }
		public string username { get; set; }
	}
}