using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace DataServer
{
	class ClientHandler
	{
		private TcpClient client;
		private List<Place> places;

		private StreamWriter writer;
		private StreamReader reader;

		private bool clientConnected;

		public ClientHandler(TcpClient client)
		{
			this.client = client;

			NetworkStream stream = client.GetStream();
			writer = new StreamWriter(stream, Encoding.ASCII) { AutoFlush = true };
			reader = new StreamReader(stream, Encoding.ASCII);

			Place place = new Place()
			{
				Longitude = 1,
				Latitude = 2,
				Title = "Title",
				Description = "Description",
				Id = 1

			};
			places = new List<Place>();
			places.Add(place);
		}

		public void Start()
		{
			clientConnected = true;
			string request = null;

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

		public void ProcessClientRequest(string request)
		{
			switch (request)
			{
				case "getAllPlaces":
					SendAllPlaces();
					break;
				case "getPlaceByID":
					SendAllPlaces();
					break;
				case "addPlace":
					SendAllPlaces();
					break;
				case "updatePlace":
					SendAllPlaces();
					break;
				case "deletePlace":
					SendAllPlaces();
					break;
				default:
					Console.WriteLine("Default was called");
					break;

			}
		}

		public void SendAllPlaces()
		{
			string placeJson;
			placeJson = JsonSerializer.Serialize(places);
			writer.WriteLine(placeJson);
		}
	}
}
