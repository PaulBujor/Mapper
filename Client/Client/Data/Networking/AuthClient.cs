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


		public async Task<User> ValidateUser(string username, string password)
		{
			User user = new User();
			try
			{
				LoginMessage loginMessage = new LoginMessage { username = username, password = _encryptor.Encrypt(password) };
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
				Console.WriteLine(user.id);
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
				user.password = _encryptor.Encrypt(user.password);
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

		public async Task<bool> CheckEmail(string message)
		{
			try
			{
				HttpClient client = new HttpClient();
				StringContent content = new StringContent(message, Encoding.UTF8, "text/plain");
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
				StringContent content = new StringContent(message, Encoding.UTF8, "text/plain");
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

		public async Task UpdateFirstName(long id, string firstname)
		{

			try
			{

				HttpClient client = new HttpClient();
				StringContent content = new StringContent(firstname, Encoding.UTF8, "text/plain");
				HttpResponseMessage responseMessage = await client.PatchAsync(URI + $"/auth/users/{id}/firstname", content);
				Console.WriteLine(responseMessage);
				if (responseMessage.StatusCode != HttpStatusCode.OK)
				{
					throw new Exception("Internal Server Error");
				}
			}
			catch (HttpRequestException e)
			{
				Console.WriteLine(e);
			}
		}

		public async Task UpdateLastName(long id, string lastname)
		{

			try
			{

				HttpClient client = new HttpClient();
				StringContent content = new StringContent(lastname, Encoding.UTF8, "text/plain");
				HttpResponseMessage responseMessage = await client.PatchAsync(URI + $"/auth/users/{id}/lastname", content);
				Console.WriteLine(responseMessage);
				if (responseMessage.StatusCode != HttpStatusCode.OK)
				{
					throw new Exception("Internal Server Error");
				}
			}
			catch (HttpRequestException e)
			{
				Console.WriteLine(e);
			}
		}

		public async Task UpdateUserName(long id, string username)
		{
			try
			{

				HttpClient client = new HttpClient();
				StringContent content = new StringContent(username, Encoding.UTF8, "text/plain");
				HttpResponseMessage responseMessage = await client.PatchAsync(URI + $"/auth/users/{id}/username", content);
				Console.WriteLine(responseMessage);
				if (responseMessage.StatusCode != HttpStatusCode.OK)
				{
					throw new Exception("Internal Server Error");
				}
			}
			catch (HttpRequestException e)
			{
				Console.WriteLine(e);
			}
		}

		public async Task UpdateEmail(long id, string email)
		{
			try
			{

				HttpClient client = new HttpClient();
				StringContent content = new StringContent(email, Encoding.UTF8, "text/plain");
				HttpResponseMessage responseMessage = await client.PatchAsync(URI + $"/auth/users/{id}/email", content);
				Console.WriteLine(responseMessage);
				if (responseMessage.StatusCode != HttpStatusCode.OK)
				{
					throw new Exception("Internal Server Error");
				}
			}
			catch (HttpRequestException e)
			{
				Console.WriteLine(e);
			}
		}

		public async Task UpdatePassword(long id, string password)
		{
			try
			{

				HttpClient client = new HttpClient();
				StringContent content = new StringContent(password, Encoding.UTF8, "text/plain");
				HttpResponseMessage responseMessage = await client.PatchAsync(URI + $"/auth/users/{id}/password", content);
				Console.WriteLine(responseMessage);
				if (responseMessage.StatusCode != HttpStatusCode.OK)
				{
					throw new Exception("Internal Server Error");
				}
			}
			catch (HttpRequestException e)
			{
				Console.WriteLine(e);
			}
		}
	}
}