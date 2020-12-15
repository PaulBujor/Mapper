using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataServer.Persistence
{
    public class ReviewImpl : IReview_Persistance
    {
        private MapDbContext dbContext;

        public ReviewImpl(MapDbContext context)
        {
            dbContext = context;
        }
        public async Task<Review> AddReview(Review review, long placeId)
        {
            Place myPlace = await dbContext.Places.FirstOrDefaultAsync(p => p.id == placeId);
            myPlace.reviews.Add(review); // Add review to the place's list of reviews
            EntityEntry<Review> newlyAdded = await dbContext.Reviews.AddAsync(review); // Add review to the table Review
            await dbContext.SaveChangesAsync();
            return newlyAdded.Entity;
        }

        public async Task<List<Review>> GetReviews(long placeId)
        {
            Place place = await dbContext.Places
                .Include(p => p.reviews)
                    .ThenInclude(r => r.addedBy)
                .Include(p => p.addedBy).
                FirstOrDefaultAsync(p => p.id == placeId);
            return place.reviews;
        }

        public async Task<Review> GetReview(long reviewId)
        {
            return await dbContext.Reviews.Include(r => r.addedBy).FirstOrDefaultAsync(r => r.id == reviewId);
        }

        public async Task RemoveReview(long reviewId)
        {
            Review toRemove = await dbContext.Reviews.FirstOrDefaultAsync(r => r.id == reviewId);
            if (toRemove != null)
            {
                await dbContext.RemovedReviews.AddAsync(toRemove);
                await dbContext.ReviewReports.Where(r => r.reportedItem.id == reviewId).ForEachAsync(r => r.resolved = true);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateReview(Review reviewItem)
        {
            try
            {
                dbContext.Update(reviewItem);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new System.Exception($"Did not find review with id{reviewItem.id}");
            }
        }
    }
}