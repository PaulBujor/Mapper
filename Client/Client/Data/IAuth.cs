using System.Threading.Tasks;
using Client.Models;

namespace Client.Data
{
    public interface IAuth
    {
        Task<User> ValidateUser(string username, string password);
        Task<User> Register(User user);
    }
}