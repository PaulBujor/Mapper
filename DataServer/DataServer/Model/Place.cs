using System;
using System.Collections.Generic;
using System.Text;

namespace DataServer.Models
{
	public class Place
	{
		public double longitude { get; set; }
		public double latitude { get; set; }
		public string title { get; set; }
		public string description { get; set; }
		public long id { get; set; }

		public Place() { }

		public Place(double longitude, double latitude, string title, string description)
		{
			this.longitude = longitude;
			this.latitude = latitude;
			this.title = title;
			this.description = description;
		}
	}
}
