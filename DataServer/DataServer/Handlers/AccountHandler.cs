using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Schema;
using DataServer.Models;

namespace DataServer.Handlers
{
	class AccountHandler : IHandler
	{

		private TcpClient client;
		private Model model;

		private StreamWriter writer;
		private StreamReader reader;

		private bool clientConnected;

		public AccountHandler(TcpClient client, Model model)
		{
			this.client = client;
			this.model = model;

			NetworkStream stream = client.GetStream();
			writer = new StreamWriter(stream, Encoding.ASCII) { AutoFlush = true };
			reader = new StreamReader(stream, Encoding.ASCII);

		}
		public async Task Start()
		{
			clientConnected = true;
			string request = null;

			//todo security protocol for connetion

			// Loop to receive all the data sent by the client.
			do
			{
				try
				{
					request = reader.ReadLine();
					Console.WriteLine("Received: {0}", request);

					await ProcessClientRequest(request);
				}
				catch (System.IO.IOException e)
				{
					clientConnected = false;
					Console.WriteLine(e.StackTrace);
				}

			} while (clientConnected);

			// Shutdown and end connection
			client.Close();
		}

		private async Task ProcessClientRequest(string request)
		{
			switch (request)
			{
				case "login":
					await Login();
					break;
				case "register":
					await Register();
					break;
				case "checkEmail":
					await CheckEmail();
					break;
				case "checkUserName":
					await CheckUsername();
					break;
				case "updateFirstName":
					await UpdateFirstname();
					break;
				case "updateLastName":
					await UpdateLastName();
					break;
				case "updateUserName":
					await UpdateUserName();
					break;
				case "updateEmail":
					await UpdateEmail();
					break;
				case "updatePassword":
					await UpdatePassword();
					break;
				default:
					Console.WriteLine("Default was called");
					break;
			}
		}


		private async Task Login()
		{
			string receivedUserName = reader.ReadLine();
			string receivedPassword = reader.ReadLine();

			User tmpUser = await model.Login(receivedUserName, receivedPassword);
			string tmpUserSerialize = JsonSerializer.Serialize(tmpUser);
			writer.WriteLine(tmpUserSerialize);

		}

		private async Task Register()
		{
			string receive = reader.ReadLine();
			User user = JsonSerializer.Deserialize<User>(receive);
			try
			{
				await model.Register(user);
				writer.WriteLine("true");
			}
			catch (Exception)
			{
				writer.WriteLine("false");
			}
		}

		private async Task CheckUsername()
		{

			string receivedUserName = reader.ReadLine();

			try
			{
				await model.CheckUsername(receivedUserName);
				writer.WriteLine("true");
			}
			catch (Exception)
			{
				writer.WriteLine("false");
			}

		}

		private async Task CheckEmail()
		{
			string receivedEmail = reader.ReadLine();
			try
			{

				await model.CheckEmail(receivedEmail);
				writer.WriteLine("true");
			}
			catch (Exception)
			{
				writer.WriteLine("false");
			}

		}

		private async Task UpdateFirstname()
		{
			long id = long.Parse(reader.ReadLine());
			string receivedName = reader.ReadLine();
			try
			{
				await model.UpdateFirstName(id, receivedName);
				writer.WriteLine("true");
			}
			catch (Exception)
			{
				writer.WriteLine("false");
			}

		}

		private async Task UpdateLastName()
		{
			long id = long.Parse(reader.ReadLine());
			string receivedLastName = reader.ReadLine();
			try
			{
				await model.UpdateLastName(id, receivedLastName);
				writer.WriteLine("true");
			}
			catch (Exception)
			{
				writer.WriteLine("false");
			}
		}

		private async Task UpdateUserName()
		{

			long id = long.Parse(reader.ReadLine());
			string receivedUserName = reader.ReadLine();

			try
			{
				await model.UpdateUsername(id, receivedUserName);
				writer.WriteLine("true");
			}
			catch (Exception)
			{
				writer.WriteLine("false");
			}
		}

		private async Task UpdateEmail()
		{
			long id = long.Parse(reader.ReadLine());
			string receivedEmail = reader.ReadLine();
			try
			{
				await model.UpdateEmail(id, receivedEmail);
				writer.WriteLine("true");
			}
			catch (Exception)
			{
				writer.WriteLine("false");
			}
		}

		private async Task UpdatePassword()
		{
			long id = long.Parse(reader.ReadLine());
			string receivedPassword = reader.ReadLine();
			Console.WriteLine(receivedPassword);
			try
			{
				await model.UpdatePassword(id, receivedPassword);
				writer.WriteLine("true");
			}
			catch (Exception)
			{
				writer.WriteLine("false");
			}

		}
	}
}
