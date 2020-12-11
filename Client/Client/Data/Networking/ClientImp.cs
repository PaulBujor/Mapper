using Client.Models;
using Client.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Client.Data.Networking.UDPListener;

namespace Client.Data.Networking
{
	public class ClientImp : IServer
	{
		private PlaceClient _place;
		private ModeratorClient _moderator;
		private ReportClient _report;
		public UDPListener listener;

		public ClientImp ()
		{
			_place = new PlaceClient();
			_moderator = new ModeratorClient();
			_report = new ReportClient();
			listener = new UDPListener();

			var subscriberThread = new Thread(_place.Subscribe);
			subscriberThread.Name = "Subscriber";
			subscriberThread.Start();

			//new Thread(() => rest.SubscribeAsync()).Start();
			var listenerThread = new Thread(listener.Run);
			listenerThread.Name = "UDP Listener";
			listenerThread.Start();
		}

		public async Task AddPlaceAsync(Place place)
		{
			await _place.AddPlaceAsync(place);
		}

		public async Task<IList<Place>> GetPlacesAsync()
		{
			return await _place.GetPlacesAsync();
		}

		public async Task ReportPlaceAsync(Report<Place> report)
		{
			await _report.ReportPlaceAsync(report);
		}

		public async Task ReportUserAsync(Report<User> report)
		{
			await _report.ReportUserAsync(report);
		}

		public async Task<List<Report<Place>>> GetPlaceReportsAsync()
		{
			return await _moderator.GetPlaceReportsAsync();
		}
		public async Task<List<Report<Review>>> GetReviewReportsAsync()
		{
			return await _moderator.GetReviewReportsAsync();
		}

		public async Task<List<Report<User>>> GetUserReportsAsync()
		{
			return await _moderator.GetUserReportsAsync();
		}

		public async Task<List<User>> GetBannedUsersAsync()
		{
			return await _moderator.GetBannedUsersAsync();
		}

		public async Task RemovePlaceAsync(long placeId)
		{
			await _moderator.RemovePlaceAsync(placeId);
		}

		public async Task DismissPlaceReportAsync(long reportId)
		{
			await _moderator.DismissPlaceReportAsync(reportId);
		}

		public async Task RemoveReviewAsync(long reviewId)
		{
			await _moderator.RemoveReviewAsync(reviewId);
		}

		public async Task DismissReviewReportAsync(long reportId)
		{
			await _moderator.DismissReviewReportAsync(reportId);
		}
		public async Task BanUserAsync(long userId)
		{
			await _moderator.BanUserAsync(userId);
		}

		public async Task UnbanUserAsync(long userId)
		{
			await _moderator.UnbanUserAsync(userId);
		}

		public async Task DismissUserReportAsync(long reportId)
		{
			await _moderator.DismissUserReportAsync(reportId);
		}


		public async Task AddPlaceReviewAsync(long placeId, Review review)
		{
			await _place.AddPlaceReviewAsync(placeId, review);
		}
	}
}
