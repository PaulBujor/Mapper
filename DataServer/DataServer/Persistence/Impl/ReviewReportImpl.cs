using System.Collections.Generic;
using System.Threading.Tasks;
using DataServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataServer.Persistence.Impl
{
    public class ReviewReportImpl : IReviewReport_Persistence
    {
        MapDbContext dbContext;

        public ReviewReportImpl()
        {
            dbContext = new MapDbContext();
        }
        public async Task CreateReviewReport(Report<Review> reviewReport)
        {
            await dbContext.ReviewReports.AddAsync(reviewReport);
            await dbContext.SaveChangesAsync();
        }

        public async Task DismissReviewReport(long reportId)
        {
            Report<Review> toDismiss = await dbContext.ReviewReports.FirstOrDefaultAsync(rr => rr.reportId == reportId);
            toDismiss.resolved = true;
        }

        public async Task<Dictionary<long, Report<Review>>> GetReviewReports()
        {
            List<Report<Review>> myList = await dbContext.ReviewReports.ToListAsync();
            Dictionary<long, Report<Review>> myDic = new Dictionary<long, Report<Review>>();
            foreach (Report<Review> item in myList)
            {
                myDic.Add(item.reportId, item);
            }
            return myDic;
        }

        public async Task UpdateReviewReport(Report<Review> reviewReport)
        {
            dbContext.ReviewReports.Update(reviewReport);
        }
    }
}