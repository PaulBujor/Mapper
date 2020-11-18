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

            /*try
            {
                
                HttpClient client = new HttpClient();
                string serialized = JsonSerializer.Serialize(PackMessage(username,_encryptor.Encrypt(password)));
                StringContent content = new StringContent(serialized, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = await client.PostAsync(URI + "/Auth", content);
                Console.WriteLine(responseMessage);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e);
            }*/
            
            
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

         public List<string> PackMessage(string username, string password)
        {
            List<string> message = new List<string>();
            message.Add(username);
            message.Add(password);
            return message;
        }
    }
}