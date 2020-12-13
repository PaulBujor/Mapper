using System.Collections.Generic;
using System.Threading.Tasks;
using DataServer.Models;

namespace DataServer.Persistence
{
    public interface IUser_Persistence
    {
        Task CreateUser(User user);

        Task<User> GetUser(string username, string password);
        Task<List<User>> GetBannedUsers();

        Task UpdateUser(User user);

        Task BanUser(long userId);

        Task UnbanUser(long userId);

        //Maybe some can be async
        public void CheckUsername(string username);
        public void CheckEmail(string email);
        public void UpdateFirstName(long id, string firstName);
        public void UpdateLastName(long id, string lastName);
        public void UpdateUsername(long id, string userName);
        public void UpdateEmail(long id, string email);
        public void UpdatePassword(long id, string password);
        User GetUserById(long userId);

        //Task<Review> AddPlaceReview(long placeId, Review review);
    }
}