using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Client.Data.Authentication;
using Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace Client.Data.Networking
{
    public class AuthClient : IAuth
    {
        private Encryptor _encryptor;

        private string URI = "http://127.0.0.1:8080";

        public AuthClient()
        {
            this._encryptor = new Encryptor();
        }


        public async  Task<User> ValidateUser(string username, string password)
        {
            User user = new User();
            try
            {
                LoginMessage loginMessage = new LoginMessage{username = username,password = _encryptor.Encrypt(password)};
                HttpClient client = new HttpClient();
                string serialized = JsonSerializer.Serialize(loginMessage);
                Console.WriteLine(serialized);
                
                StringContent content = new StringContent(serialized, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = await client.PostAsync(URI + "/auth", content);
          
                var reponseContent = await responseMessage.Content.ReadAsStringAsync();
                 user = JsonSerializer.Deserialize<User>(reponseContent);
                Console.WriteLine("Testing returns:");
                Console.WriteLine(user.username);
                Console.WriteLine(user.password);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e);
            }
            return user;
            }

        public async Task Register(User user)
        {
            try
            {
                HttpClient client = new HttpClient();
                string userSerialized = JsonSerializer.Serialize(user);
                StringContent content = new StringContent(userSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = await client.PostAsync(URI + "/reg", content);
                /*Console.WriteLine(responseMessage);*/
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e);
            }
        }
        public Task EditProfile(User user)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> CheckEmail(string message)
        {
            try
            {
                HttpClient client = new HttpClient();
                string emailSerialized = JsonSerializer.Serialize(message);
                StringContent content = new StringContent(emailSerialized, Encoding.UTF8, "text/plain");
                HttpResponseMessage responseMessage = await client.PostAsync(URI + "/email", content);
               
                if (responseMessage.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

        public async Task<bool> CheckUserName(string message)
        {
   
            try
            {
                HttpClient client = new HttpClient();
                string emailSerialized = JsonSerializer.Serialize(message);
                StringContent content = new StringContent(emailSerialized, Encoding.UTF8, "text/plain");
                HttpResponseMessage responseMessage = await client.PostAsync(URI + "/uname", content);
               if (responseMessage.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e);
            }
            return false;
        }
    }
}