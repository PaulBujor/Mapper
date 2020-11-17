using DataServer.Models;
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
        private Model model;

        private StreamWriter writer;
        private StreamReader reader;

        private bool clientConnected;

        public ClientHandler(TcpClient client, Model model)
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
                    AddPlace();
                    break;
                case "updatePlace":
                    UpdatePlace();
                    break;
                case "deletePlace":
                    DeletePlace();
                    break;
                case "getAllReports":
                    GetAllReports();
                    break;
                case "removeReview":
                    break;
                case "banUser":
                    break;
                case "unbanUser":
                    break;
                case "authenticateUser":
                    AuthenticateUser();
                    break;
                default:
                    Console.WriteLine("Default was called");
                    break;

            }
        }

        public void SendAllPlaces()
        {
            string placeJson;
            placeJson = JsonSerializer.Serialize(model.GetAllPlaces());
            writer.WriteLine(placeJson);
        }

        public void AddPlace()
        {
            string receive;
            receive = reader.ReadLine();
            Place place = JsonSerializer.Deserialize<Place>(receive);
            string placeJson;
            placeJson = JsonSerializer.Serialize(model.AddPlace(place));
            writer.WriteLine(placeJson);
        }

        public void UpdatePlace()
        {
            string receive;
            receive = reader.ReadLine();
            Place place = JsonSerializer.Deserialize<Place>(receive);

            model.UpdatePlace(place);
        }

        public void DeletePlace()
        {
            long receive = long.Parse(reader.ReadLine());
            model.DeletePlace(receive);
        }

        public void GetAllReports()
		{
            writer.WriteLine(JsonSerializer.Serialize(model.GetAllPlaces()));
		}

        public void AuthenticateUser()
		{
            string receive = reader.ReadLine();
            User user = JsonSerializer.Deserialize<User>(receive);
            writer.WriteLine(model.AuthroizeUser(user));
		}
    }
}
