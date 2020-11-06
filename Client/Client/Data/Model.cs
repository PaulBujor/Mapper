using Client.Data.Networking;
using Client.Models;
using Client.Networking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Data
{
	public class Model : IModel
	{
		private IList<Place> places;
		private readonly IServer server;

		public Model()
		{
			server = new ClientImp();
			//LoadPlaces();
		}

		private void LoadPlaces()
		{
			places = server.GetPlacesAsync().Result;
		}

		public async Task AddPlaceAsync(Place place)
		{
			//await server.AddPlaceAsync(place);
			places.Add(place);
		}

		public IList<Place> GetPlaces()
		{
			return places;
		}
	}
}
