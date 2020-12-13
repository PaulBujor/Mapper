using DataServer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataServer.Handlers
{
	class ModeratorHandler : IHandler
	{
		private TcpClient client;
		private Model model;

		private StreamWriter writer;
		private StreamReader reader;

		private bool clientConnected;

		public ModeratorHandler(TcpClient client, Model model)
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
				catch (System.IO.IOException)
				{
					clientConnected = false;
				}

			} while (clientConnected);

			// Shutdown and end connection
			client.Close();
		}

		private async Task ProcessClientRequest(string request)
		{
			switch (request)
			{
				case "getPlaceReports":
					await GetPlaceReports();
					break;
				case "getReviewReports":
					await GetReviewReports();
					break;
				case "getUserReports":
					await GetUserReports();
					break;
				case "getBannedUsers":
					await GetBannedUsers();
					break;

				case "removePlace":
					await RemovePlace();
					break;
				case "removeReview":
					await RemoveReview();
					break;
				case "banUser":
					await BanUser();
					break;
				case "unbanUser":
					await UnbanUser();
					break;
				case "getUserById":
					await GetUserById();
					break;
				case "dismissPlaceReport":
					await DismissPlaceReport();
					break;
				case "dismissReviewReport":
					await DismissReviewReport();
					break;
				case "dismissUserReport":
					await DismissUserReport();
					break;
				case "authorizeUser":
					await AuthorizeUser();
					break;
				default:
					Console.WriteLine("Default was called");
					break;
			}
		}

		private async Task GetBannedUsers()
		{
			writer.WriteLine(JsonSerializer.Serialize(await model.GetBannedUsers()));
		}

		private async Task GetUserById()
		{
			long userId = long.Parse(reader.ReadLine());
			writer.WriteLine(JsonSerializer.Serialize(await model.GetUserById(userId)));
		}

		private async Task DismissPlaceReport()
		{
			long reportId = long.Parse(reader.ReadLine());
			await model.DismissPlaceReport(reportId);
		}

		private async Task DismissReviewReport()
		{
			long reportId = long.Parse(reader.ReadLine());
			await model.DismissPlaceReport(reportId);
		}

		private async Task DismissUserReport()
		{
			long reportId = long.Parse(reader.ReadLine());
			await model.DismissPlaceReport(reportId);
		}

		private async Task UnbanUser()
		{
			long userId = long.Parse(reader.ReadLine());
			await model.UnbanUser(userId);
		}

		private async Task BanUser()
		{
			long userId = long.Parse(reader.ReadLine());
			await model.BanUser(userId);
		}

		private async Task RemoveReview()
		{
			long reviewId = long.Parse(reader.ReadLine());
			await model.RemoveReview(reviewId);
		}

		public async Task RemovePlace()
		{
			long placeId = long.Parse(reader.ReadLine());
			await model.RemovePlace(placeId);
		}

		private async Task GetUserReports()
		{
			writer.WriteLine(JsonSerializer.Serialize(await model.GetUserReports()));
		}

		private async Task GetReviewReports()
		{
			writer.WriteLine(JsonSerializer.Serialize(await model.GetReviewReports()));
		}

		private async Task GetPlaceReports()
		{
			writer.WriteLine(JsonSerializer.Serialize(await model.GetPlaceReports()));
		}

		private async Task AuthorizeUser()
		{
			string receive = reader.ReadLine();
			User user = JsonSerializer.Deserialize<User>(receive);
			writer.WriteLine(await model.AuthroizeUser(user));
		}
	}
}
