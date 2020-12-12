using DataServer.Models;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;


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
				case "reportPlace":
					ReportsPlace();
					break;
				case "reportReview":
					ReportReview();
					break;
				case "reportUser":
					ReportUser();
					break;
				default:
					Console.WriteLine("Default was called");
					break;
			}
		}

		private void ReportUser()
		{
			Report<User> reportedUser = JsonSerializer.Deserialize<Report<User>>(reader.ReadLine());
			model.AddUserReport(reportedUser);
		}

		private void ReportReview()
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			string aux = reader.ReadLine();
			Console.WriteLine(aux);
			Report<Review> reportedReview = js.Deserialize<Report<Review>>(aux);
            Console.WriteLine("Report id " + reportedReview.reportId);
			Console.WriteLine("Report id " + reportedReview.reportedItem.id);
			model.AddReviewReport(reportedReview);
		}

		private void ReportsPlace()
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			string aux = reader.ReadLine();
            Console.WriteLine(aux);
			Report<Place> reportedPlace = js.Deserialize<Report<Place>>(aux);

			/*Report<PlaceForDeserialization> reportedPlaceForDeserialization = JsonSerializer.Deserialize<Report<PlaceForDeserialization>>(aux);
			Report<Place> reportedPlace = new Report<Place>();
			reportedPlace.reportedItem = new Place(reportedPlaceForDeserialization.reportedItem);
			reportedPlace.reportedClass = reportedPlaceForDeserialization.reportedClass;*/
			model.AddPlaceReport(reportedPlace);
		}
	}
}
