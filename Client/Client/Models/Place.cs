using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Models
{
	[Serializable]
	public class Place
	{
		public long id { get; set; }
		public double longitude { get; set; }
		public double latitude { get; set; }
		public string title { get; set; }
		public string description { get; set; }
		public List<Review> reviews { get; set; }
		public UserData addedBy { get; set; }

		public Place()
		{
			reviews = new List<Review>();
		}

		public Place(double longitude, double latitude, string title, string description)
		{
			this.longitude = longitude;
			this.latitude = latitude;
			this.title = title;
			this.description = description;
			reviews = new List<Review>();
		}

		public void AddReview(Review review)
		{
			reviews.Add(review);
		}

		public double GetRating()
		{
			long score = 0;
			foreach (Review item in reviews)
			{
				score += item.rating;
			}
			return (double)score / reviews.Count;
		}

		public List<Review> GetReviews()
		{
			return reviews;
		}
	}
}
