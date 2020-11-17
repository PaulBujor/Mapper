using System;
using System.Threading.Tasks;
using Client.Data.Authentication;
using Client.Models;

namespace Client.Data.Networking
{
    public class AuthClient 
    {




        public  User ValidateUser(string username, string password)
        {
            if (username.Equals("test1") && password.Equals("test"))
            {
                return new User{username = "tester",auth = 1,password = "teest"};
            }
            if (username.Equals("test2") && password.Equals("test"))
            {
                return new User{username = "tester",auth = 2,password = "teest"};
            }

            return null;
        }
    }
}