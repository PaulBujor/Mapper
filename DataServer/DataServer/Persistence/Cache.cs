using DataServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServer.Persistence
{
	public class Cache : IPersistence
	{
		private long placeKey = 0;
		private long reviewKey = 0;
		private long userKey = 0;
		private long reportKey = 0;

		private Dictionary<long, Place> places;
		private Dictionary<long, User> users;
		private Dictionary<string, long> usernames;

		private Dictionary<long, Report<Place>> placeReports;
		private Dictionary<long, Report<ReviewItem>> reviewReports;
		private Dictionary<long, Report<User>> userReports;

		private List<long> removedPlaces;
		private List<long> removedReviews;
		private List<long> bannedUsers;

		public Cache()
		{
			places = new Dictionary<long, Place>();
			users = new Dictionary<long, User>();
			usernames = new Dictionary<string, long>();

			placeReports = new Dictionary<long, Report<Place>>();
			reviewReports = new Dictionary<long, Report<ReviewItem>>();
			userReports = new Dictionary<long, Report<User>>();

			removedPlaces = new List<long>();
			removedReviews = new List<long>();
			bannedUsers = new List<long>();

		}

		public async Task<Place> AddPlace(Place place)
		{
			places.Add(++placeKey, place);
			place.id = placeKey;
			return place;
		}

		public async Task AddReview(ReviewItem review, long placeId)
		{
			Place place;
			places.TryGetValue(placeId, out place);
			review.id = ++reviewKey;
			place.reviews.AddReview(review);
		}

		public async Task BanUser(long userId)
		{
			users[userId].auth = 0;
			userReports.Values.ToList().ForEach(report => { if (report.reportedItem.id == userId) report.resolved = true; });
		}

		public async Task CreatePlaceReport(Report<Place> placeReport)
		{
			placeReport.reportId = ++reportKey;
			placeReports.Add(reportKey, placeReport);
		}

		public async Task CreateReviewReport(Report<ReviewItem> reviewReport)
		{
			reviewReport.reportId = ++reportKey;
			reviewReports.Add(reportKey, reviewReport);
		}

		public async Task CreateUser(User user)
		{
			user.id = ++userKey;
			users.Add(userKey, user);
		}

		public async Task CreateUserReport(Report<User> userReport)
		{
			userReport.reportId = ++reportKey;
			userReports.Add(reportKey, userReport);
		}

		public async Task<Place> GetPlace(long id)
		{
			Place place;
			places.TryGetValue(id, out place);
			return place;
		}

		public async Task<List<Place>> GetPlaces()
		{
			return places.Values.Where(c => !removedPlaces.Contains(c.id)).ToList();
		}

		public async Task<List<ReviewItem>> GetReviews(long placeId)
		{
			return GetPlace(placeId).Result.reviews.GetReviews().Where(c => !removedReviews.Contains(c.id)).ToList();
		}

		public async Task<User> GetUser(string username, string password)
		{
			long userId;
			usernames.TryGetValue(username, out userId);
			User user;
			users.TryGetValue(userId, out user);
			if (user.password.Equals(password))
				return user;
			return null;
		}

		public async Task<bool> CheckUserExists(string username)
		{
			return usernames.ContainsKey(username);
		}

		public async Task RemovePlace(long placeId)
		{
			removedPlaces.Add(placeId);
			placeReports.Values.ToList().ForEach(report => { if (report.reportedItem.id == placeId) report.resolved = true; });
		}

		public async Task RemoveReview(long reviewId)
		{
			removedReviews.Add(reviewId);
			reviewReports.Values.ToList().ForEach(report => { if (report.reportedItem.id == reviewId) report.resolved = true; });
		}

		public async Task UnbanUser(long userId)
		{
			users[userId].auth = 1;
		}

		public async Task UpdatePlace(Place place)
		{
			places[place.id] = place;
		}

		public async Task UpdatePlaceReport(Report<Place> placeReport)
		{
			placeReports[placeReport.reportId] = placeReport;
		}

		public async Task UpdateReview(ReviewItem reviewItem)
		{
			//todo
		}

		public async Task UpdateReviewReport(Report<ReviewItem> reviewReport)
		{
			reviewReports[reviewReport.reportId] = reviewReport;
		}

		public async Task UpdateUser(User user)
		{
			//todo check validation
			users[user.id] = user;
		}

		public async Task UpdateUserReport(Report<User> userReport)
		{
			userReports[userReport.reportId] = userReport;
		}

		public async Task<Dictionary<long, Report<Place>>> GetPlaceReports()
		{
			return placeReports;
		}

		public async Task<Dictionary<long, Report<ReviewItem>>> GetReviewReports()
		{
			return reviewReports;
		}

		public async Task<Dictionary<long, Report<User>>> GetUserReports()
		{
			return userReports;
		}

		public async Task<ReviewItem> AddPlaceReview(long placeId, ReviewItem review)
		{
			Place place;
			places.TryGetValue(placeId, out place);
			place.reviews.AddReview(review);
			review.id = ++reviewKey;

			Console.WriteLine("Reitan id: " + place.id + " " + "Reitan rating " + place.reviews.GetRating());

			return review;
		}
	}
}
