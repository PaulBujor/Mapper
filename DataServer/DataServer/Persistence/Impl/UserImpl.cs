using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataServer.Persistence
{
    public class UserImpl : IUser_Persistence
    {
        private MapDbContext dbContext;

        public UserImpl()
        {
            dbContext = new MapDbContext();
        }

        /*public Task<Review> AddPlaceReview(long placeId, Review review)
        {
            throw new System.NotImplementedException();
        }*/

        public async Task BanUser(long userId)
        {
            User myUser = dbContext.Users.FirstOrDefault(u => u.id == userId);
            myUser.auth = 0;
        }

        public async Task CheckEmail(string email)
        {
            //User toGet = dbContext.Users.FirstOrDefault(u => u.email == email);
            if (dbContext.Users.FirstOrDefault(u => u.email == email) == null)
            {
                System.Console.WriteLine("e-mail available");
            }
            throw new System.Exception("E-mail already in used");

        }

        public async Task CheckUsername(string username)
        {
            //User toGet = dbContext.Users.FirstOrDefault(u => u.username == username);
            if (dbContext.Users.FirstOrDefault(u => u.username == username) == null)
            {
                System.Console.WriteLine("username available");
            }
            throw new System.Exception("Username already in used");
        }

        public async Task CreateUser(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }

        public async Task<User> GetUser(string username, string password)
        {
            User toGet = dbContext.Users.FirstOrDefault(u => u.username == username && u.password.Equals(password));
            return toGet;
        }

        public async Task<User> GetUserById(long userId)
        {
            User toGet = dbContext.Users.FirstOrDefault(u => u.id == userId);
            return toGet;
        }

        public async Task UnbanUser(long userId)
        {
            User myUser = dbContext.Users.FirstOrDefault(u => u.id == userId);
            myUser.auth = 1;
        }

        public async Task UpdateEmail(long id, string email)
        {
            User toGet = dbContext.Users.FirstOrDefault(u => u.id == id);
            toGet.email = email;
        }

        public async Task UpdateFirstName(long id, string firstName)
        {
            User toGet = dbContext.Users.FirstOrDefault(u => u.id == id);
            toGet.firstName = firstName;
        }

        public async Task UpdateLastName(long id, string lastName)
        {
            User toGet = dbContext.Users.FirstOrDefault(u => u.id == id);
            toGet.lastName = lastName;
        }

        public async Task UpdatePassword(long id, string password)
        {
            User toGet = dbContext.Users.FirstOrDefault(u => u.id == id);
            toGet.password = password;
        }

        public async Task UpdateUser(User user)
        {
            dbContext.Users.Update(user);
        }

        public async Task UpdateUsername(long id, string userName)
        {
            User toGet = dbContext.Users.FirstOrDefault(u => u.id == id);
            toGet.username = userName;
        }

        public async Task<List<User>> GetBannedUsers()
        {
            List<User> listOfUsers = await dbContext.Users.ToListAsync();
            List<User> banUsers = new List<User>();
            foreach (User user in listOfUsers)
            {
                if (user.auth == 0)
                {
                    banUsers.Add(user);
                }
            }
            return banUsers;
        }

        public async Task AddSavedPlace(long userId, Place place)
        {
            User u = await GetUserById(userId);
            u.savedPlaces.Add(place);
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveSavedPlace(long userId, Place place)
        {
            User user = await dbContext.Users.FirstOrDefaultAsync(u => u.id == userId);
            user.savedPlaces.RemoveAll(p => p.id == place.id);
            await dbContext.SaveChangesAsync();
        }
    }
}