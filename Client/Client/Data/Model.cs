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
			server.listener.OnUpdatePlace += UpdatePlace;
		}

		private void LoadPlaces()
		{
			places = server.GetPlacesAsync().Result;
			OnMapLoaded?.Invoke();
            System.Console.WriteLine(places.FirstOrDefault().GetRating());
		}

		public override async Task AddPlaceAsync(Place place)
		{
			await server.AddPlaceAsync(place);
			//places.Add(place);
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

		public override async Task<List<Report<Review>>> GetReviewReportsAsync()
		{
			return await server.GetReviewReportsAsync();
		}

		public override async Task<List<Report<User>>> GetUserReportsAsync()
		{
			return await server.GetUserReportsAsync();
		}

		public override async Task<List<User>> GetBannedUsersAsync()
		{
			return await server.GetBannedUsersAsync();
		}

		public override async Task RemovePlaceAsync(long placeId)
		{
			await server.RemovePlaceAsync(placeId);
		}

		public override async Task DismissPlaceReportAsync(long reportId)
		{
			await server.DismissPlaceReportAsync(reportId);
		}

		public override async Task RemoveReviewAsync(long reviewId)
		{
			await server.RemoveReviewAsync(reviewId);
		}

		public override async Task DismissReviewReportAsync(long reportId)
		{
			await server.DismissReviewReportAsync(reportId);
		}
		public override async Task BanUserAsync(long userId)
		{
			await server.BanUserAsync(userId);
		}

		public override async Task UnbanUserAsync(long userId)
		{
			await server.UnbanUserAsync(userId);
		}

		public override async Task DismissUserReportAsync(long reportId)
		{
			await server.DismissUserReportAsync(reportId);
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

		public override async Task ReportUserAsync(User user)
		{
			Report<User> report = new Report<User>
			{
				reportedItem = user,
				reportedClass = "User"
			};
			await server.ReportUserAsync(report);
		}

		public override Place GetPlaceById(long id)
        {
			return GetPlaces().FirstOrDefault(p => p.id.Equals(id));
		}

		public override async Task AddPlaceReviewAsync(long placeId, Review r)
		{
			await server.AddPlaceReviewAsync(placeId, r);
		}

		public override async Task AddSavedPlaceAsync(long userId, long placeId)
		{
			await server.AddSavedPlaceAsync(userId, placeId);
		}

		public override async Task RemoveSavedPlaceAsync(long userId, long placeId)
		{
			await server.RemoveSavedPlaceAsync(userId, placeId);
		}

		private void UpdatePlace(Place place)
		{
			//possible bug here
			places.Remove(GetPlaceById(place.id));
			places.Add(place);
		}

        
    }
}
