using DataServer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataServer.Models
{
	class ReviewFull : IReview
	{
		public List<ReviewItem> reviews { get; set; }

		public ReviewFull()
		{
			reviews = new List<ReviewItem>();
		}

		public double GetRating()
		{
			long score = 0;
			foreach (ReviewItem item in reviews)
			{
				score += item.rating;
			}
			return (double)score / reviews.Count;
		}

		public List<ReviewItem> GetReviews()
		{
			return reviews;
		}

		public void AddReview(ReviewItem review)
		{
			reviews.Add(review);
		}
	}
}
