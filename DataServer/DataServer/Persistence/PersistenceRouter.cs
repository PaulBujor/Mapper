using System.Collections.Generic;
using System.Threading.Tasks;
using DataServer.Models;
using DataServer.Persistence.Impl;

namespace DataServer.Persistence
{
    public class PersistenceRouter : IPlaces_Persistance, IPlacesReport_Persistence, IReview_Persistance, IReviewReport_Persistence, IUser_Persistence, IUserReport_Persistence
    {
        IPlaces_Persistance places;
        IPlacesReport_Persistence placesReport;
        IUser_Persistence users;
        IUserReport_Persistence usersReport;
        IReview_Persistance reviews;
        IReviewReport_Persistence reviewsReport;

        public PersistenceRouter()
        {
            places = new PlacesImpl();
            placesReport = new PlacesReportImpl();
            users = new UserImpl();
            usersReport = new UserReportImpl();
            reviews = new ReviewImpl();
            reviewsReport = new ReviewReportImpl();
        }

        //IPlaces_Persistence
        public async Task<Place> AddPlace(Place place)
        {
            return await places.AddPlace(place);
        }
        public async Task<Place> GetPlace(long id)
        {
            return await places.GetPlace(id);
        }
        public async Task<List<Place>> GetPlaces()
        {
            return await places.GetPlaces();
        }
        public async Task RemovePlace(long id)
        {
            await places.RemovePlace(id);
        }

        public async Task UpdatePlace(Place place)
        {
            await places.UpdatePlace(place);
        }

        //IPlacesReport_Persistence
        public async Task CreatePlaceReport(Report<Place> placeReport)
        {
            await placesReport.CreatePlaceReport(placeReport);
        }

        public async Task DismissPlaceReport(long reportId)
        {
            await placesReport.DismissPlaceReport(reportId);
        }

        //public Task<Dictionary<long, Report<Place>>> GetPlaceReports()
        public async Task<List<Report<Place>>> GetPlaceReports()
        {
            return await placesReport.GetPlaceReports();
        }

        public async Task UpdatePlaceReport(Report<Place> placeReport)
        {
            await placesReport.UpdatePlaceReport(placeReport);
        }

        //IReview_Persistence
        public async Task<Review> AddReview(Review review, long placeId)
        {
            return await reviews.AddReview(review, placeId);
        }

        public async Task<List<Review>> GetReviews(long placeId)
        {
            return await reviews.GetReviews(placeId);
        }

        public async Task RemoveReview(long reviewId)
        {
            await reviews.RemoveReview(reviewId);
        }

        public async Task UpdateReview(Review reviewItem)
        {
            await reviews.UpdateReview(reviewItem);
        }

        //IReviewReport_Persistence
        public async Task CreateReviewReport(Report<Review> reviewReport)
        {
            await reviewsReport.CreateReviewReport(reviewReport);
        }

        public async Task DismissReviewReport(long reportId)
        {
            await reviewsReport.DismissReviewReport(reportId);
        }

        //public Task<Dictionary<long, Report<Review>>> GetReviewReports()
        public async Task<List<Report<Review>>> GetReviewReports()
        {
            return await reviewsReport.GetReviewReports();
        }

        public async Task UpdateReviewReport(Report<Review> reviewReport)
        {
            await reviewsReport.UpdateReviewReport(reviewReport);
        }

        //IUser_Persistence
        public async Task BanUser(long userId)
        {
            await users.BanUser(userId);
        }

        public async Task CheckEmail(string email)
        {
            await users.CheckEmail(email);
        }

        public async Task CheckUsername(string username)
        {
            await users.CheckUsername(username);
        }

        public async Task CreateUser(User user)
        {
            await users.CreateUser(user);
        }

        public async Task<User> GetUser(string username, string password)
        {
            return await users.GetUser(username, password);
        }

        public async Task<User> GetUserById(long userId)
        {
            return await users.GetUserById(userId);
        }

        public async Task UnbanUser(long userId)
        {
            await users.UnbanUser(userId);
        }

        public async Task UpdateEmail(long id, string email)
        {
            await users.UpdateEmail(id, email);
        }

        public async Task UpdateFirstName(long id, string firstName)
        {
            await users.UpdateFirstName(id, firstName);
        }

        public async Task UpdateLastName(long id, string lastName)
        {
            await users.UpdateLastName(id, lastName);
        }

        public async Task UpdatePassword(long id, string password)
        {
            await users.UpdatePassword(id, password);
        }

        public async Task UpdateUser(User user)
        {
            await users.UpdateUser(user);
        }

        public async Task UpdateUsername(long id, string userName)
        {
            await users.UpdateUsername(id, userName);
        }

        public async Task<List<User>> GetBannedUsers()
        {
            return await users.GetBannedUsers();
        }

        //IUserReport_Persistence

        public async Task CreateUserReport(Report<User> userReport)
        {
            await usersReport.CreateUserReport(userReport);
        }

        public async Task DismissUserReport(long reportId)
        {
            await usersReport.DismissUserReport(reportId);
        }

        //public Task<Dictionary<long, Report<User>>> GetUserReports()
        public async Task<List<Report<User>>> GetUserReports()
        {
            return await usersReport.GetUserReports();
        }

        public async Task UpdateUserReport(Report<User> userReport)
        {
            await usersReport.UpdateUserReport(userReport);
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