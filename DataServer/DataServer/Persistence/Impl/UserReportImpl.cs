using System.Collections.Generic;
using System.Threading.Tasks;
using DataServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataServer.Persistence.Impl
{
    public class UserReportImpl : IUserReport_Persistence
    {
        private MapDbContext dbContext;

        public UserReportImpl()
        {
            dbContext = new MapDbContext();
        }
        public async Task CreateUserReport(Report<User> userReport)
        {
            EntityEntry<Report<User>> newlyAdded = await dbContext.UserReports.AddAsync(userReport);
            await dbContext.SaveChangesAsync();
        }

        public async Task DismissUserReport(long reportId)
        {
            Report<User> toDismiss = await dbContext.UserReports.FirstOrDefaultAsync(ur => ur.reportId == reportId);
            toDismiss.resolved = true;
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Report<User>>> GetUserReports()
        {
            return await dbContext.UserReports.ToListAsync();
        }

        public async Task UpdateUserReport(Report<User> userReport)
        {
            dbContext.UserReports.Update(userReport);
            await dbContext.SaveChangesAsync();
        }

        /*public async Task<List<Report<User>>> IUserReport_Persistence.GetUserReports()
        {
            return await dbContext.UserReports.ToListAsync();
        }*/
    }
}