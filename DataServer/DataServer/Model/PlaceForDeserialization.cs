using DataServer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataServer.Models
{
	public class PlaceForDeserialization
	{
		public double id { get; set; }
		public double longitude { get; set; }
		public double latitude { get; set; }
		public string title { get; set; }
		public string description { get; set; }
		public ReviewFull reviews { get; set; }


		public PlaceForDeserialization() { }

		public PlaceForDeserialization(double longitude, double latitude, string title, string description)
		{
			this.longitude = longitude;
			this.latitude = latitude;
			this.title = title;
			this.description = description;
		}
	}
}
