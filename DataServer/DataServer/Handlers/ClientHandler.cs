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
    class ClientHandler : IHandler
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

        //this method routes to the correct method based on the first received request
        private async Task ProcessClientRequest(string request)
        {
            switch (request)
            {
                case "getAllPlaces":
                    await SendAllPlaces();
                    break;
                case "getPlaceByID":
                    await SendAllPlaces();
                    break;
                case "addPlace":
                    await AddPlace();
                    break;
                case "updatePlace":
                    await UpdatePlace();
                    break;
                case "authenticateUser":
                    await AuthenticateUser();
                    break;
                case "addPlaceReview":
                    await AddPlaceReview();
                    break;
                case "addSavedPlace":
                    await AddSavedPlace();
                    break;
                case "removeSavedPlace":
                    await RemoveSavedPlace();
                    break;
                default:
                    Console.WriteLine("Default was called");
                    break;

            }
        }

        //todo
        private async Task SendAllPlaces()
        {
            string placeJson;
            placeJson = JsonSerializer.Serialize(await model.GetAllPlacesAsync());
            writer.WriteLine(placeJson);
        }

        private async Task AddPlace()
        {
            string receive;
            receive = reader.ReadLine();
			Console.WriteLine(receive);
            PlaceLite place = JsonSerializer.Deserialize<PlaceLite>(receive);
            await model.AddPlace(place);
            string placeJson = JsonSerializer.Serialize(place);
            writer.WriteLine(placeJson);
        }

        private async Task UpdatePlace()
        {
            string receive;
            receive = reader.ReadLine();
            PlaceLite place = JsonSerializer.Deserialize<PlaceLite>(receive);

            await model.UpdatePlace(place);
        }

        private async Task AuthenticateUser()
        {
            string receive = reader.ReadLine();
            User user = JsonSerializer.Deserialize<User>(receive);
            writer.WriteLine(await model.AuthroizeUser(user));
        }

        private async Task AddPlaceReview()
        {
            string receivePlaceId = reader.ReadLine();
            string receiveReviewItem = reader.ReadLine();
            long placeId = long.Parse(receivePlaceId);
            ReviewLite review = JsonSerializer.Deserialize<ReviewLite>(receiveReviewItem);
            writer.WriteLine(JsonSerializer.Serialize(await model.AddPlaceReview(placeId, review)));
        }

        private async Task AddSavedPlace()
        {
            Console.WriteLine("AddSavedPlace called");
            string receiveUserId = reader.ReadLine();
            string receivePlaceId = reader.ReadLine();
            long userId = long.Parse(receiveUserId);
            long placeId = long.Parse(receivePlaceId);
            await model.AddSavedPlace(userId, placeId);
        }

        private async Task RemoveSavedPlace()
        {
            Console.WriteLine("RempveSavedPlace called");
            string receiveUserId = reader.ReadLine();
            string receivePlaceId = reader.ReadLine();
            long userId = long.Parse(receiveUserId);
            long placeId = long.Parse(receivePlaceId);
            await model.RemoveSavedPlace(userId, placeId);
        }

    }
}
