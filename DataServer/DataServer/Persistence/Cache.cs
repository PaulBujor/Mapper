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
		private Dictionary<long, Report<Review>> reviewReports;
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
			reviewReports = new Dictionary<long, Report<Review>>();
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

		public async Task AddReview(Review review, long placeId)
		{
			Place place;
			places.TryGetValue(placeId, out place);
			review.id = ++reviewKey;
			place.AddReview(review);
		}

		public async Task AddSavedPlace(long userId, long placeId)
		{
			User user;
			users.TryGetValue(userId, out user);
			Place place;
			places.TryGetValue(placeId, out place);
			Console.WriteLine("SavedPlaces = " + user.savedPlaces.Count);
			user.savedPlaces.Add(place);
            Console.WriteLine("SavedPlaces = " + user.savedPlaces.Count);
		}

		public async Task RemoveSavedPlace(long userId, long placeId)
		{
			User user;
			users.TryGetValue(userId, out user);
			Console.WriteLine("SavedPlaces = " + user.savedPlaces.Count);
			user.savedPlaces.RemoveAll(p => p.id == placeId);
			Console.WriteLine("SavedPlaces = " + user.savedPlaces.Count);
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

		public async Task CreateReviewReport(Report<Review> reviewReport)
		{
			reviewReport.reportId = ++reportKey;
			reviewReports.Add(reportKey, reviewReport);
            Console.WriteLine($"Number of reviewReports {reviewReports.Count}");
		}

		public async Task CreateUserReport(Report<User> userReport)
		{
			userReport.reportId = ++reportKey;
			userReports.Add(reportKey, userReport);
		}

		public async Task CreateUser(User user)
		{
			user.id = ++userKey;
			users.Add(userKey, user);
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

		public async Task<List<Review>> GetReviews(long placeId)
		{
			return GetPlace(placeId).Result.GetReviews().Where(c => !removedReviews.Contains(c.id)).ToList();
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

		public async Task UpdateReview(Review reviewItem)
		{
			//todo
		}

		public async Task UpdateReviewReport(Report<Review> reviewReport)
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

		public async Task<Dictionary<long, Report<Review>>> GetReviewReports()
		{
			return reviewReports;
		}

		public async Task<Dictionary<long, Report<User>>> GetUserReports()
		{
			return userReports;
		}

		public async Task<Review> AddPlaceReview(long placeId, Review review)
		{
			Place place;
			places.TryGetValue(placeId, out place);
			place.AddReview(review);
			review.id = ++reviewKey;

			Console.WriteLine("Reitan id: " + place.id + " " + "Reitan rating " + place.GetRating());

			return review;
		}

		public async Task DismissPlaceReport(long reportId)
		{
			Report<Place> report;
			placeReports.TryGetValue(reportId, out report);
			report.resolved = true;
		}

		public async Task DismissReviewReport(long reportId)
		{
			Report<Review> report;
			reviewReports.TryGetValue(reportId, out report);
			report.resolved = true;
		}

		public async Task DismissUserReport(long reportId)
		{
			Report<User> report;
			userReports.TryGetValue(reportId, out report);
			report.resolved = true;
		}

		public User GetUserById(long userId)
		{
			User user;
			users.TryGetValue(userId, out user);
			return user;
		}
		
		public void Register(User user)
		{
			users.Add(user.id, user);
		}

		public void CheckUsername(string username)
		{
			throw new NotImplementedException();
		}

		public void CheckEmail(string email)
		{
			throw new NotImplementedException();
		}

		public void UpdateFirstName(long id, string firstName)
		{
			throw new NotImplementedException();
		}

		public void UpdateLastName(long id, string lastName)
		{
			throw new NotImplementedException();
		}

		public void UpdateUsername(long id, string userName)
		{
			throw new NotImplementedException();
		}

		public void UpdateEmail(long id, string email)
		{
			throw new NotImplementedException();
		}

		public void UpdatePassword(long id, string password)
		{
			throw new NotImplementedException();
		}

		public async Task<Dictionary<long, User>> GetBannedUsers()
		{
			return (Dictionary<long, User>) users.Where(u => u.Value.auth == 0);
		}
	}
}
