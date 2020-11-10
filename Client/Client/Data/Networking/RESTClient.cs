using Client.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client.Networking
{
    class RESTClient : IServer
    {
        /*
        static async Task Main(string[] args)
        {
            Task data = new Program().GetData();
            await data;
        }*/
        private string URI = "http://localhost:8080";


        public async Task<IList<Place>> GetPlacesAsync()
        {
            HttpClient client = new HttpClient();
            Task<string> stringAsync = client.GetStringAsync(URI + "/places");
            string message = await stringAsync;
            List<Place> result = JsonSerializer.Deserialize<List<Place>>(message);
            return result;
        }

        public async Task AddPlaceAsync(Place place)
        {
            HttpClient client = new HttpClient();
            string placeSerialized = JsonSerializer.Serialize(place);

            StringContent content = new StringContent(
                placeSerialized,
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await client.PostAsync(URI + "/places", content);
			Console.WriteLine(response.ToString());
        }

        //for testing i suppose :)
        private async Task GetData()
        {
            HttpClient client = new HttpClient();
            string stringAsync = await client.GetStringAsync(URI + "/places");   //not sure about the "/places"
            Console.WriteLine(stringAsync);
        }

        private async Task<string> PostData()
        {
            HttpClient client = new HttpClient();
            Place place = new Place
            {
                Latitude = 42.33669,
                Longitude = -7.86407,
                Title = "Ou-city",
                Description = "Thermal capital of Spain and 2nd Thermal capital of Europe."
            };

            string placeSerialized = JsonSerializer.Serialize(place);

            StringContent content = new StringContent(
                placeSerialized,
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await client.PostAsync(URI + "/places", content);
            return response.ToString();
        }
    }
}