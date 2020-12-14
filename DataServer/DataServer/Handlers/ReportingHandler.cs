using DataServer.Models;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataServer.Handlers
{
	class ReportingHandler : IHandler
	{
		private TcpClient client;
		private Model model;

		private StreamWriter writer;
		private StreamReader reader;

		private bool clientConnected;
		public ReportingHandler(TcpClient client, Model model)
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
				case "reportPlace":
					await ReportPlace();
					break;
				case "reportReview":
					await ReportReview();
					break;
				case "reportUser":
					await ReportUser();
					break;
				default:
					Console.WriteLine("Default was called");
					break;
			}
		}

		private async Task ReportUser()
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			Report<UserData> reportedUser = js.Deserialize<Report<UserData>>(reader.ReadLine());
			await model.AddUserReport(reportedUser);
		}

		private async Task ReportReview()
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			string aux = reader.ReadLine();
			Console.WriteLine(aux);
			Report<ReviewLite> reportedReview = js.Deserialize<Report<ReviewLite>>(aux);
            Console.WriteLine("Report id " + reportedReview.reportId);
			Console.WriteLine("Report id " + reportedReview.reportedItem.id);
			await model.AddReviewReport(reportedReview);
		}

		private async Task ReportPlace()
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			string aux = reader.ReadLine();
            Console.WriteLine(aux);
			Report<PlaceLite> reportedPlace = js.Deserialize<Report<PlaceLite>>(aux);

			/*Report<PlaceForDeserialization> reportedPlaceForDeserialization = JsonSerializer.Deserialize<Report<PlaceForDeserialization>>(aux);
			Report<Place> reportedPlace = new Report<Place>();
			reportedPlace.reportedItem = new Place(reportedPlaceForDeserialization.reportedItem);
			reportedPlace.reportedClass = reportedPlaceForDeserialization.reportedClass;*/
			await model.AddPlaceReport(reportedPlace);
		}
	}
}
