using System.Collections.Generic;
using System.Threading.Tasks;
using DataServer.Models;

namespace DataServer.Persistence
{
    public interface IPlaces_Persistance
    {
        Task AddPlace(Place place);

        Task<List<Place>> GetPlaces();

        Task<Place> GetPlace(long id);

        Task UpdatePlace(Place place);

        Task RemovePlace(long id);
    }
}