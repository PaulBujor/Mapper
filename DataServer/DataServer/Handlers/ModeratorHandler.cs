using DataServer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

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

		public void Start()
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

					ProcessClientRequest(request);
				}
				catch (System.IO.IOException e)
				{
					clientConnected = false;
				}

			} while (clientConnected);

			// Shutdown and end connection
			client.Close();
		}

		private void ProcessClientRequest(string request)
		{
			switch (request)
			{
				case "getPlaceReports":
					GetPlaceReports();
					break;
				case "getReviewReports":
					GetReviewReports();
					break;
				case "getUserReports":
					GetUserReports();
					break;

				case "removePlace":
					RemovePlace();
					break;
				case "removeReview":
					RemoveReview();
					break;
				case "banUser":
					BanUser();
					break;
				case "unbanUser":
					UnbanUser();
					break;
				case "dismissReport":
					DismissReport();
					break;
				case "authorizeUser":
					AuthorizeUser();
					break;
				default:
					Console.WriteLine("Default was called");
					break;
			}
		}

		private void DismissReport()
		{
			long reportId = long.Parse(reader.ReadLine());
			model.DismissReport(reportId);
		}

		private void UnbanUser()
		{
			long userId = long.Parse(reader.ReadLine());
			model.UnbanUser(userId);
		}

		private void BanUser()
		{

			long userId = long.Parse(reader.ReadLine());
			model.BanUser(userId);
		}

		private void RemoveReview()
		{
			long reviewId = long.Parse(reader.ReadLine());
			model.RemoveReview(reviewId);
		}

		public void RemovePlace()
		{
			long placeId = long.Parse(reader.ReadLine());
			model.RemovePlace(placeId);
		}

		private void GetUserReports()
		{
			writer.WriteLine(JsonSerializer.Serialize(model.GetUserReports().Result));
		}

		private void GetReviewReports()
		{
			writer.WriteLine(JsonSerializer.Serialize(model.GetReviewReports().Result));
		}

		private void GetPlaceReports()
		{
			writer.WriteLine(JsonSerializer.Serialize(model.GetPlaceReports()));
		}

		private void AuthorizeUser()
		{
			string receive = reader.ReadLine();
			User user = JsonSerializer.Deserialize<User>(receive);
			writer.WriteLine(model.AuthroizeUser(user));
		}
	}
}
