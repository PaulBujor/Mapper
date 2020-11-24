using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Data
{
    public class ReviewFull : IReview
    {
        double rating;
        List<ReviewItem> reviews;

        public int GetRating()
        {
            throw new NotImplementedException();
        }

        List<ReviewItem> GetReviews()
        {
            throw new NotImplementedException();
        }

    }
}
