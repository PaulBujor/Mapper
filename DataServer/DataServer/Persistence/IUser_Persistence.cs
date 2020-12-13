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
        Task CheckUsername(string username);
        Task CheckEmail(string email);
        Task UpdateFirstName(long id, string firstName);
        Task UpdateLastName(long id, string lastName);
        Task UpdateUsername(long id, string userName);
        Task UpdateEmail(long id, string email);
        Task UpdatePassword(long id, string password);
        Task<User> GetUserById(long userId);
        Task AddSavedPlace(long userId, Place place);
        Task RemoveSavedPlace(long userId, Place place);

        //Task<Review> AddPlaceReview(long placeId, Review review);
    }
}