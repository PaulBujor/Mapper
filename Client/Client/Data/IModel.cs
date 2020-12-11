using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Client.Data.Model;

namespace Client.Data
{
	public abstract class IModel
	{
		public delegate void MapChange(Place place);
		public MapChange OnNewPlace;

		public delegate void MapLoaded();
		public MapLoaded OnMapLoaded;

		public abstract Task AddPlaceAsync(Place place);

		public abstract IList<Place> GetPlaces();
		public abstract Place GetPlaceById(long id);

		public abstract Task<List<Report<Place>>> GetPlaceReportsAsync();

		public abstract Task<List<Report<ReviewItem>>> GetReviewReportsAsync();

		public abstract Task<List<Report<User>>> GetUserReportsAsync();

		public abstract Task<List<User>> GetBannedUsersAsync();

		public abstract Task RemovePlaceAsync(long placeId);

		public abstract Task DismissPlaceReportAsync(long reportId);

		public abstract Task ReportPlaceAsync(long id);

		public abstract Task RemoveReviewAsync(long reviewId);

		public abstract Task DismissReviewReportAsync(long reportId);
		public abstract Task BanUserAsync(long userId);

		public abstract Task UnbanUserAsync(long userId);

		public abstract Task DismissUserReportAsync(long reportId);

		public abstract Task ReportUserAsync(User user);
		public abstract Task AddPlaceReviewAsync(long placeId, Review r);
		public abstract Task AddSavedPlaceAsync(long userId, long placeId);

		public abstract Task RemoveSavedPlaceAsync(long userId, long placeId);

	}
}
