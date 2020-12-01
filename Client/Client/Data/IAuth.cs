using System.Threading.Tasks;
using Client.Models;

namespace Client.Data
{
    public interface IAuth
    {
        Task<User> ValidateUser(string username, string password);
        Task Register(User user);
        Task EditProfile(User user);
      
        Task<bool> CheckEmail(string message);
        Task<bool> CheckUserName(string message);

        Task EditFirstName(long id,string firstname);
        Task EditLastName(long id, string lastname);
        Task EditUserName(long id, string username);
        Task EditEmail(long id, string email);
        Task ChangePassword(long id, string password);
    }
}