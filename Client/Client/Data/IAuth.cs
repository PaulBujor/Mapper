using System.Threading.Tasks;
using Client.Models;

namespace Client.Data
{
    public interface IAuth
    {
        Task<User> ValidateUser(string username, string password);
        Task Register(User user);
      
        Task<bool> CheckEmail(string message);
        Task<bool> CheckUserName(string message);

        Task UpdateLastName(long id, string lastname);
        Task UpdateFirstName(long id,string firstname);
        Task UpdateUserName(long id, string username);
        Task UpdateEmail(long id, string email);
        Task UpdatePassword(long id, string password);
    }
}