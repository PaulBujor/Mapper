using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Data
{
    public class ReviewLite : IReview
    {
        double rating;
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
