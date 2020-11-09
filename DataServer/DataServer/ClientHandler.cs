using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace DataServer
{
    class ClientHandler
    {
        private TcpClient client;
        private List<Place> places;
        private NetworkStream stream;
        Byte[] bytes;
        String data;

        public ClientHandler(TcpClient client)
        {
            this.client = client;
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
            stream = client.GetStream();
            bytes = new Byte[256];
            data = null;
            int i;

            // Loop to receive all the data sent by the client.
            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                // Translate data bytes to a ASCII string.
                data = Encoding.ASCII.GetString(bytes, 0, i);
                Console.WriteLine("Received: {0}", data);

                ProcessClientRequest(data);

            }

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
                case "getAllPlaces\r\n":
                    Console.WriteLine(@"getAllPlaces\r\n CALLED");
                    SendAllPlaces();
                    break;
                default:
                    Console.WriteLine("Default was called");
                    break;

            }
        }

        public void SendAllPlaces()
        {
            string jsonString;
            jsonString = JsonSerializer.Serialize(places);
            Byte[] msg = Encoding.ASCII.GetBytes(jsonString);
            /*bytes = Encoding.ASCII.GetBytes(jsonString);*/
            stream.Write(msg, 0, msg.Length);
        }



    }
}
