using DataServer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataServer.Persistence
{
	public interface IPersistence
	{
		//TODO some of these probably dont need to be async since some wait for data to be finished, and socket shouldnt do something else

		//PLACES CRUD
		Task<Place> AddPlace(Place place);

		Task<List<Place>> GetPlaces();

		Task<Place> GetPlace(long id);

		Task UpdatePlace(Place place);

		Task RemovePlace(long id);

		Task AddSavedPlace(long userId, long placeId);

		Task RemoveSavedPlace(long userId, long placeId);

		//REVIEW CRUD
		Task AddReview(Review review, long placeId);

		Task<List<Review>> GetReviews(long placeId);

		Task UpdateReview(Review reviewItem);

		Task RemoveReview(long reviewId);

		//USER CRUD
		Task CreateUser(User user);

		Task<User> GetUser(string username, string password);

		Task UpdateUser(User user);

		Task BanUser(long userId);

		Task UnbanUser(long userId);

		//Maybe some can be async
		public void Register(User user);
		public void CheckUsername(string username);
		public void CheckEmail(string email);
		public void UpdateFirstName(long id, string firstName);
		public void UpdateLastName(long id, string lastName);
		public void UpdateUsername(long id, string userName);
		public void UpdateEmail(long id, string email);
		public void UpdatePassword(long id, string password);

		//REPORT CRUD
		Task CreatePlaceReport(Report<Place> placeReport);

		Task CreateReviewReport(Report<Review> reviewReport);

		Task CreateUserReport(Report<User> userReport);

		Task UpdatePlaceReport(Report<Place> placeReport);

		Task UpdateReviewReport(Report<Review> reviewReport);

		Task UpdateUserReport(Report<User> userReport);

		Task<Dictionary<long, Report<Place>>> GetPlaceReports();

		Task<Dictionary<long, Report<Review>>> GetReviewReports();

		Task<Dictionary<long, Report<User>>> GetUserReports();

		Task<Dictionary<long, User>> GetBannedUsers();

		Task<Review> AddPlaceReview(long placeId, Review review);

		Task DismissPlaceReport(long reportId);

		public Task DismissReviewReport(long reportId);

		public Task DismissUserReport(long reportId);
		User GetUserById(long userId);
	}
}
