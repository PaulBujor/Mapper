using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataServer.Persistence.Impl
{
    public class ReportImpl : IReport_Persitance
    {
        MapDbContext dbContext;

        public ReportImpl()
        {
            dbContext = new MapDbContext();
        }
        /*public async Task CreatePlaceReport(Report<Place> placeReport)
        {
            EntityEntry<Report<Place>> newlyAdded = await dbContext.PlaceReports.AddAsync(placeReport);
            await dbContext.SaveChangesAsync();
            //return newlyAdded.Entity;
        }*/

        /*public async Task CreateReviewReport(Report<Review> reviewReport)
        {
            EntityEntry<Report<Review>> newlyAdded = await dbContext.Reviews.AddAsync(reviewReport);
            await dbContext.SaveChangesAsync();
        }*/

        /*public async Task CreateUserReport(Report<User> userReport)
        {
            EntityEntry<Report<User>> newlyAdded = await dbContext.UserReports.AddAsync(userReport);
            await dbContext.SaveChangesAsync();
        }*/

        /*public async Task DismissPlaceReport(long reportId)
        {
            Report<Place> toDismiss = await dbContext.PlaceReports.FirstOrDefaultAsync(pr => pr.reportId == reportId);
            toDismiss.resolved = true;
        }*/

        /*public async Task DismissReviewReport(long reportId)
        {
            Report<Review> toDismiss = await dbContext.ReviewReports.FirstOrDefaultAsync(rr => rr.reportId == reportId);
            toDismiss.resolved = true;
        }*/

        /*public async Task DismissUserReport(long reportId)
        {
            Report<User> toDismiss = await dbContext.PlaceReports.FirstOrDefaultAsync(ur => ur.reportId == reportId);
            toDismiss.resolved = true;
        }*/

        /*public async Task<Dictionary<long, Report<Place>>> GetPlaceReports()
        {
            return await dbContext.PlaceReports.ToDictionaryAsync();
        }*/

        /*public async Task<Dictionary<long, Report<Review>>> GetReviewReports()
        {
            return await dbContext.ReviewReports.ToDictionaryAsync();
        }*/

        /*public async Task<Dictionary<long, Report<User>>> GetUserReports()
        {
            return await dbContext.UserReports.ToDictionaryAsync();
        }*/

        /*public async Task UpdatePlaceReport(Report<Place> placeReport)
        {
            dbContext.PlaceReports.Update(placeReport);
        }*/

        /*public async Task UpdateReviewReport(Report<Review> reviewReport)
        {
            dbContext.ReviewReports.Update(reviewReport);
        }*/

        /*public async Task UpdateUserReport(Report<User> userReport)
        {
            dbContext.UserReports.Update(userReport);
        }*/
    }
}