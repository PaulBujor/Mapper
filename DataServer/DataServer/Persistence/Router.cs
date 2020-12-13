using System.Collections.Generic;
using System.Threading.Tasks;
using DataServer.Models;
using DataServer.Persistence.Impl;

namespace DataServer.Persistence
{
    public class Router : IPlaces_Persistance, IPlacesReport_Persistence, IReview_Persistance, IReviewReport_Persistence, IUser_Persistence, IUserReport_Persistence
    {
        IPlaces_Persistance places;
        IPlacesReport_Persistence placesReport;
        IUser_Persistence users;
        IUserReport_Persistence usersReport;
        IReview_Persistance reviews;
        IReviewReport_Persistence reviewsReport;

        public Router()
        {
            places = new PlacesImpl();
            placesReport = new PlacesReportImpl();
            users = new UserImpl();
            usersReport = new UserReportImpl();
            reviews = new ReviewImpl();
            reviewsReport = new ReviewReportImpl();
        }

        //IPlaces_Persistence
        public Task<Place> AddPlace(Place place)
        {
            return places.AddPlace(place);
        }
        public Task<Place> GetPlace(long id)
        {
            return places.GetPlace(id);
        }
        public Task<List<Place>> GetPlaces()
        {
            return places.GetPlaces();
        }
        public Task RemovePlace(long id)
        {
            return places.RemovePlace(id);
        }

        public Task UpdatePlace(Place place)
        {
            return places.UpdatePlace(place);
        }

        //IPlacesReport_Persistence
        public Task CreatePlaceReport(Report<Place> placeReport)
        {
            return placesReport.CreatePlaceReport(placeReport);
        }

        public Task DismissPlaceReport(long reportId)
        {
            return placesReport.DismissPlaceReport(reportId);
        }

        //public Task<Dictionary<long, Report<Place>>> GetPlaceReports()
        public async Task<List<Report<Place>>> GetPlaceReports()
        {
            return await placesReport.GetPlaceReports();
        }

        public Task UpdatePlaceReport(Report<Place> placeReport)
        {
            return placesReport.UpdatePlaceReport(placeReport);
        }

        //IReview_Persistence
        public Task AddReview(Review review, long placeId)
        {
            return reviews.AddReview(review, placeId);
        }

        public Task<List<Review>> GetReviews(long placeId)
        {
            return reviews.GetReviews(placeId);
        }

        public Task RemoveReview(long reviewId)
        {
            return reviews.RemoveReview(reviewId);
        }

        public Task UpdateReview(Review reviewItem)
        {
            return reviews.UpdateReview(reviewItem);
        }

        //IReviewReport_Persistence
        public Task CreateReviewReport(Report<Review> reviewReport)
        {
            return reviewsReport.CreateReviewReport(reviewReport);
        }

        public Task DismissReviewReport(long reportId)
        {
            return reviewsReport.DismissReviewReport(reportId);
        }

        //public Task<Dictionary<long, Report<Review>>> GetReviewReports()
        public async Task<List<Report<Review>>> GetReviewReports()
        {
            return await reviewsReport.GetReviewReports();
        }

        public Task UpdateReviewReport(Report<Review> reviewReport)
        {
            return reviewsReport.UpdateReviewReport(reviewReport);
        }

        //IUser_Persistence
        public Task BanUser(long userId)
        {
            return users.BanUser(userId);
        }

        public void CheckEmail(string email)
        {
            users.CheckEmail(email);
        }

        public void CheckUsername(string username)
        {
            users.CheckUsername(username);
        }

        public Task CreateUser(User user)
        {
            return users.CreateUser(user);
        }

        public Task<User> GetUser(string username, string password)
        {
            return users.GetUser(username, password);
        }

        public User GetUserById(long userId)
        {
            return users.GetUserById(userId);
        }

        public Task UnbanUser(long userId)
        {
            return users.UnbanUser(userId);
        }

        public void UpdateEmail(long id, string email)
        {
            users.UpdateEmail(id, email);
        }

        public void UpdateFirstName(long id, string firstName)
        {
            users.UpdateFirstName(id, firstName);
        }

        public void UpdateLastName(long id, string lastName)
        {
            users.UpdateLastName(id, lastName);
        }

        public void UpdatePassword(long id, string password)
        {
            users.UpdatePassword(id, password);
        }

        public Task UpdateUser(User user)
        {
            return users.UpdateUser(user);
        }

        public void UpdateUsername(long id, string userName)
        {
            users.UpdateUsername(id, userName);
        }

        public async Task<List<User>> GetBannedUsers()
        {
            return await users.GetBannedUsers();
        }

        //IUserReport_Persistence

        public Task CreateUserReport(Report<User> userReport)
        {
            return usersReport.CreateUserReport(userReport);
        }

        public Task DismissUserReport(long reportId)
        {
            return usersReport.DismissUserReport(reportId);
        }

        //public Task<Dictionary<long, Report<User>>> GetUserReports()
        public async Task<List<Report<User>>> GetUserReports()
        {
            return await usersReport.GetUserReports();
        }

        public Task UpdateUserReport(Report<User> userReport)
        {
            return usersReport.UpdateUserReport(userReport);
        }

        public async Task AddSavedPlace(long userId, Place place)
        {
            await users.AddSavedPlace(userId, place);
        }

        public async Task RemoveSavedPlace(long userId, Place place)
        {
            await users.RemoveSavedPlace(userId, place);
        }
    }
}