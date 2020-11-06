using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Models
{
	public class Place
	{
		public double Longitude { get; set; }
		public double Latitude { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }

		public Place() { }

		public Place(double longitude, double latitude, string title, string description)
		{
			Longitude = longitude;
			Latitude = latitude;
			Title = title;
			Description = description;
		}
	}
}
