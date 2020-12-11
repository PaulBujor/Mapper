using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataServer.Persistence
{
    public class ReviewImpl : IReview_Persistance
    {
        private MapDbContext dbContext;

        public ReviewImpl()
        {
            dbContext = new MapDbContext();
        }
        public async Task AddReview(Review review, long placeId)
        {
            Place myPlace = await dbContext.Places.FirstOrDefaultAsync(p => p.id == placeId);
            myPlace.reviews.Add(review); // Add review to the place's list of reviews
            EntityEntry<Review> newlyAdded = await dbContext.Reviews.AddAsync(review); // Add review to the table Review
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Review>> GetReviews(long placeId)
        {
            Place place = await dbContext.Places.FirstOrDefaultAsync(p => p.id == placeId);
            return place.reviews;
        }

        public async Task RemoveReview(long reviewId)
        {
            Review toRemove = await dbContext.Reviews.FirstOrDefaultAsync(r => r.id == reviewId);
            if (toRemove != null)
            {
                dbContext.Reviews.Remove(toRemove);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateReview(Review reviewItem)
        {
            try
            {
                dbContext.Update(reviewItem);
                dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new System.Exception($"Did not find review with id{reviewItem.id}");
            }
        }
    }
}