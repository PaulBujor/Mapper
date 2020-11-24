using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Data
{
    public class ReviewFull : IReview
    {
        List<ReviewItem> reviews;

        public ReviewFull()
        {
            reviews = new List<ReviewItem>();
        }

        public void AddReview(ReviewItem review)
        {
            reviews.Add(review);
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
    }
}
