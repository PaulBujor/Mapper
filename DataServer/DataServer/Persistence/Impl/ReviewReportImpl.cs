using System.Collections.Generic;
using System.Threading.Tasks;
using DataServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataServer.Persistence.Impl
{
    public class ReviewReportImpl : IReviewReport_Persistence
    {
        private MapDbContext dbContext;

        public ReviewReportImpl(MapDbContext context)
        {
            dbContext = context;
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
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Report<Review>>> GetReviewReports()
        {
            return await dbContext.ReviewReports
                .Include(r => r.reportedItem)
                .ThenInclude(r => r.addedBy)
                .ToListAsync();
        }

        public async Task UpdateReviewReport(Report<Review> reviewReport)
        {
            dbContext.ReviewReports.Update(reviewReport);
            await dbContext.SaveChangesAsync();
        }
    }
}