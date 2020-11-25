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

        public async Task<Message> CheckEmail(string message)
        {
            Message tmpMessageSend= new Message{text = message};
            Message tmpMessage = new Message();
            try
            {
                HttpClient client = new HttpClient();
                string emailSerialized = JsonSerializer.Serialize(tmpMessageSend);
                StringContent content = new StringContent(emailSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = await client.PostAsync(URI + "/email", content);
                Console.WriteLine(responseMessage);
                
                var reponseContent = await responseMessage.Content.ReadAsStringAsync();
                 tmpMessage = JsonSerializer.Deserialize<Message>(reponseContent);
                 Console.WriteLine($"Returned result : {tmpMessage.text}");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine(message);
            return tmpMessage;


        }

        public async Task<Message> CheckUserName(string message)
        {
            Message tmpMessage = new Message();
            Message tmpMessageSend = new Message {text = message};
            try
            {
                HttpClient client = new HttpClient();
                string emailSerialized = JsonSerializer.Serialize(tmpMessageSend);
                StringContent content = new StringContent(emailSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = await client.PostAsync(URI + "/uname", content);
                /*Console.WriteLine(responseMessage);*/
                
                var reponseContent = await responseMessage.Content.ReadAsStringAsync();
                tmpMessage = JsonSerializer.Deserialize<Message>(reponseContent);
                Console.WriteLine($"Returned username AuthClient: {tmpMessage.text}");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e);
            }

            return tmpMessage;

        }
    }
}