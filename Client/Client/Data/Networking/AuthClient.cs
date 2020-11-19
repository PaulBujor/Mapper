using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Client.Data.Authentication;
using Client.Models;

namespace Client.Data.Networking
{
    public class AuthClient
    {
        private Encryptor _encryptor;

        private string URI = "http://127.0.0.1:8080";



        public async  Task<User> ValidateUser(string username, string password)
        {

            /*Console.WriteLine("test");
            try
            {
                
                HttpClient client = new HttpClient();
                string serialized = JsonSerializer.Serialize(PackMessage(username,_encryptor.Encrypt(password)));
                
                StringContent content = new StringContent(serialized, Encoding.UTF8, "application/json");
                Console.WriteLine(content);
                HttpResponseMessage responseMessage = await client.PostAsync(URI + "/auth", content);
                Console.WriteLine(responseMessage);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e);
            }*/

            /*
            LoginMessage loginMessage = PackMessage(username, _encryptor.Encrypt(password));
            Console.WriteLine("test");
            Console.WriteLine(loginMessage.password.ToString());*/
            
            
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

         public LoginMessage PackMessage(string username, string password)
        {
            LoginMessage loginMessage = new LoginMessage{username= username,password=password};
            return loginMessage;
        }
    }
}