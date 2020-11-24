using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Data;
using Client.Models;

namespace Client.Models
{
	public class Place
	{
		public double longitude { get; set; }
		public double latitude { get; set; }
		public string title { get; set; }
		public string description { get; set; }
		public long id { get; set; }
		public IReview reviews { get; set; }


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
