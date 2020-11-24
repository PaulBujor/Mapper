using System.Collections.Generic;

namespace DataServer.Models
{
	public interface IReview
	{
		double GetRating();
		List<ReviewItem> GetReviews();
	}
}