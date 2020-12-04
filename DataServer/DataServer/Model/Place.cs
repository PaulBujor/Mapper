using System;
using System.Collections.Generic;
using System.Text;

namespace DataServer.Models
{
	[Serializable]
	public class Place
	{
		public long id { get; set; }
		public double longitude { get; set; }
		public double latitude { get; set; }
		public string title { get; set; }
		public string description { get; set; }
		public ReviewFull reviews { get; set; }

		public Place()
		{
		}

		public Place(double longitude, double latitude, string title, string description)
		{
			this.longitude = longitude;
			this.latitude = latitude;
			this.title = title;
			this.description = description;
			reviews = new ReviewFull();
		}

		public Place(PlaceForDeserialization place)
		{
			id = (long) place.id;
			longitude = place.longitude;
			latitude = place.latitude;
			title = place.title;
			description = place.description;
			reviews = place.reviews;
		}
	}
}
