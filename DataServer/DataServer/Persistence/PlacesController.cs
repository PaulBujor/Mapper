using System.Collections.Generic;
using System.Threading.Tasks;
using DataServer.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataServer.Persistence
{
    public class PlacesController : IPlaces_Persistance
    {
        private MapDbContext dbContext;
        public PlacesController()
        {
            dbContext = new MapDbContext();
        }
        public async Task<Place> AddPlace(Place place)
        {
            EntityEntry<Place> newlyAdded = await dbContext.Places.AddAsync(place);
            await dbContext.SaveChangesAsync();
            return newlyAdded.Entity;
        }

        public Task<Place> GetPlace(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Place>> GetPlaces()
        {
            throw new System.NotImplementedException();
        }

        public Task RemovePlace(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdatePlace(Place place)
        {
            throw new System.NotImplementedException();
        }
    }
}