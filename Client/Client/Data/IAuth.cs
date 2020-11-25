using System.Threading.Tasks;
using Client.Models;

namespace Client.Data
{
    public interface IAuth
    {
        Task<User> ValidateUser(string username, string password);
        Task Register(User user);
        Task<Message> CheckEmail(string message);
        Task<Message> CheckUserName(string message);
    }
}