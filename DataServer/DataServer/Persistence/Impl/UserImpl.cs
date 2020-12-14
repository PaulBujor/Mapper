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

        public UserImpl(MapDbContext context)
        {
            dbContext = context;
        }

        /*public Task<Review> AddPlaceReview(long placeId, Review review)
        {
            throw new System.NotImplementedException();
        }*/

        public async Task BanUser(long userId)
        {
            User myUser = dbContext.Users.FirstOrDefault(u => u.id == userId);
            myUser.auth = 0;
            await dbContext.SaveChangesAsync();
        }

        public Task CheckEmail(string email)
        {
            //User toGet = dbContext.Users.FirstOrDefault(u => u.email == email);
            User toGet = dbContext.Users.FirstOrDefault(u => u.email == email);
            if (!(toGet == null))
            {
                throw new System.Exception("E-mail already in used");
            }
            else
            {
                System.Console.WriteLine("e-mail available");
                return null;
            }

        }

        public Task CheckUsername(string username)
        {
            User toGet = dbContext.Users.FirstOrDefault(u => u.username == username);
            if (!(toGet == null))
            {
                throw new System.Exception("Username already in used");
            }
            else
            {
                System.Console.WriteLine("username available");
                return null;
            }
        }

        public async Task CreateUser(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }

        public async Task<User> GetUser(string username, string password)
        {
            //User toGet = dbContext.Users.Select(u => u.username == username && u.password.Equals(password));
            return await dbContext.Users
                .Include(u => u.savedPlaces)
                    .ThenInclude(p => p.reviews)
                        .ThenInclude(r => r.addedBy)
                .Include(u => u.savedPlaces)
                    .ThenInclude(p => p.addedBy)
                .FirstOrDefaultAsync(u => u.username.Equals(username) && u.password.Equals(password));
        }

        public async Task<User> GetUserById(long userId)
        {
            return await dbContext.Users
                .Include(u => u.savedPlaces)
                    .ThenInclude(p => p.reviews)
                        .ThenInclude(r => r.addedBy)
                .Include(u => u.savedPlaces)
                    .ThenInclude(p => p.addedBy)
                .FirstOrDefaultAsync(u => u.id == userId);
        }

        public async Task UnbanUser(long userId)
        {
            User myUser = (User)dbContext.Users.Where(u => u.id == userId);
            myUser.auth = 1;
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateEmail(long id, string email)
        {
            User toGet = (User)dbContext.Users.Where(u => u.id == id);
            toGet.email = email;
            System.Console.WriteLine($"updating email to {toGet.email}");
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateFirstName(long id, string firstName)
        {
            User toGet = (User)dbContext.Users.Where(u => u.id == id);
            toGet.firstName = firstName;
            System.Console.WriteLine($"updating first name to {toGet.firstName}");
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateLastName(long id, string lastName)
        {
            User toGet = (User)dbContext.Users.Where(u => u.id == id);
            toGet.lastName = lastName;
            System.Console.WriteLine($"updating last name to {toGet.lastName}");
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdatePassword(long id, string password)
        {
            User toGet = (User)dbContext.Users.Where(u => u.id == id);
            toGet.password = password;
            System.Console.WriteLine($"updating pasword to ******");
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            dbContext.Users.Update(user);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateUsername(long id, string userName)
        {
            User toGet = (User)dbContext.Users.Where(u => u.id == id);
            toGet.username = userName;
            System.Console.WriteLine($"updating username to {toGet.username}");
            await dbContext.SaveChangesAsync();
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