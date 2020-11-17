using Client.Data.Networking;
using Client.Models;
using Client.Networking;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Data
{
	public class Model : IModel
	{
		private IList<Place> places;
		private readonly ClientImp server;

		public Model()
		{
			server = new ClientImp();
			var loaderThread = new Thread(LoadPlaces);
			loaderThread.Name = "Init Place Loader";
			loaderThread.Start();
			server.listener.OnNewPlace += ReceivePlace;
		}

		private void LoadPlaces()
		{
			places = server.GetPlacesAsync().Result;
			OnMapLoaded?.Invoke();
		}

		public override async Task AddPlaceAsync(Place place)
		{
			await server.AddPlaceAsync(place);
			places.Add(place);
		}

		public override IList<Place> GetPlaces()
		{
			return places;
		}

		private void ReceivePlace(Place place)
		{
			places.Add(place);
			OnNewPlace?.Invoke(place);
		}
	}
}
