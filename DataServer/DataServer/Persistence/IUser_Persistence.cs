using System.Collections.Generic;
using System.Threading.Tasks;
using DataServer.Models;

namespace DataServer.Persistence
{
    public interface IUser_Persistence
    {
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

        Task<Review> AddPlaceReview(long placeId, Review review);

        Task DismissPlaceReport(long reportId);

        public Task DismissReviewReport(long reportId);

        public Task DismissUserReport(long reportId);
        User GetUserById(long userId);
    }
}