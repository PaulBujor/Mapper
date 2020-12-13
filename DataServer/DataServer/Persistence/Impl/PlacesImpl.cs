using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataServer.Persistence
{
    public class PlacesImpl : IPlaces_Persistance
    {
        private MapDbContext dbContext;
        public PlacesImpl()
        {
            dbContext = new MapDbContext();
        }
        public async Task<Place> AddPlace(Place place)
        {
            EntityEntry<Place> newlyAdded = await dbContext.Places.AddAsync(place);
            await dbContext.SaveChangesAsync();
            return newlyAdded.Entity;
        }

        public async Task<Place> GetPlace(long id)
        {
            Place toGet = await dbContext.Places.FirstOrDefaultAsync(p => p.id == id);
            return toGet;
        }

        public async Task<List<Place>> GetPlaces()
        {
            return await dbContext.Places.ToListAsync();
        }

        public async Task RemovePlace(long id)
        {
            Place toRemove = await dbContext.Places.FirstOrDefaultAsync(p => p.id == id);
            if (toRemove != null)
            {
                dbContext.Places.Remove(toRemove);
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
                throw new System.Exception($"Did not find place with id{place.id}");
            }
        }
    }
}