using System.Collections.Generic;
using System.Threading.Tasks;
using DataServer.Models;

namespace DataServer.Persistence
{
    public interface IReviewReport_Persistence
    {
         Task CreateReviewReport(Report<Review> reviewReport);
         Task UpdateReviewReport(Report<Review> reviewReport);
         Task<Dictionary<long, Report<Review>>> GetReviewReports();
         public Task DismissReviewReport(long reportId);
    }
}