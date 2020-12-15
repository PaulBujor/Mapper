using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataServer.Persistence
{
    public class PlacesImpl : IPlaces_Persistance
    {
        private MapDbContext dbContext;
        public PlacesImpl(MapDbContext context)
        {
            dbContext = context;
        }
        public async Task AddPlace(Place place)
        {
            await dbContext.Places.AddAsync(place);
			//Console.WriteLine(newlyAdded.Entity.id);
            await dbContext.SaveChangesAsync();
            //return newlyAdded.Entity;
        }

        public async Task<Place> GetPlace(long id)
        {
            Place toGet = await dbContext.Places
                .Include(p => p.reviews)
                    .ThenInclude(r => r.addedBy)
                .Include(p => p.addedBy).
                FirstOrDefaultAsync(p => p.id == id);
            return toGet;
        }

        public async Task<List<Place>> GetPlaces()
        {
            return await dbContext.Places
                .Where(p => !p.removed)
                .Include(p => p.addedBy)
                .Include(p => p.reviews.Where(r => !r.removed))
                    .ThenInclude(r => r.addedBy)
                .ToListAsync();
        }

        public async Task RemovePlace(long id)
        {
            Place toRemove = await dbContext.Places.FirstOrDefaultAsync(p => p.id == id);
            if (toRemove != null)
            {
                toRemove.removed = true;
                await dbContext.PlaceReports.Where(r => r.reportedItem.id == id).ForEachAsync(r => r.resolved = true);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdatePlace(Place place)
        {
            try
            {
                //Place toUpdate = await dbContext.Places.FirstAsync(p => p.id == place.id);
                dbContext.Update(place); //Love EF
                await dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"Did not find place with id{place.id}");
                throw new System.Exception(e.Message);
            }
        }
    }
}