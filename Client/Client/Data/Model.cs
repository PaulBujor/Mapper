using Client.Data.Networking;
using Client.Models;
using Client.Networking;
using System.Collections.Generic;
using System.Linq;
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

		public override async Task<List<Report<Place>>> GetPlaceReportsAsync()
		{
			return await server.GetPlaceReportsAsync();
		}

		public override async Task RemovePlaceAsync(long placeId)
		{
			await server.RemovePlaceAsync(placeId);
		}

		public override async Task DismissPlaceReportAsync(long reportId)
		{
			await server.DismissReportAsync(reportId);
		}
		
		public override async Task ReportPlaceAsync(long id)
		{
			Place place = GetPlaces().FirstOrDefault(p => p.id.Equals(id));
			Report<Place> report = new Report<Place>
			{
				reportedItem = place,
				reportedClass = "Place"
			};
			await server.ReportPlaceAsync(report);
		}

		public override Place GetPlaceById(long id)
        {
			return GetPlaces().FirstOrDefault(p => p.id.Equals(id));
		}
    }
}
