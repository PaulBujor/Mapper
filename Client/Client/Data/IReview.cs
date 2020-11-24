using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Data
{
    public interface IReview
    {
        double GetRating();
        List<ReviewItem> GetReviews();

    }
}
