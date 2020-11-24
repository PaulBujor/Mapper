using DataServer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataServer.Models
{
	class ReviewLite : IReview
	{
		public double rating { get; set; }
		public double GetRating()
		{
			return rating;
		}

		public List<ReviewItem> GetReviews()
		{
			return null;
		}
	}
}
