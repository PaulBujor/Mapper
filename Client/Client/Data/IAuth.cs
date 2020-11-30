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
    }
}