using Client.Data;
using Client.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client.Networking
{
	class PlaceClient
	{
		/*
        static async Task Main(string[] args)
        {
            Task data = new Program().GetData();
            await data;
        }*/
		private string URI = "http://127.0.0.1:8080";

		public void Subscribe()
		{
			HttpClient client = new HttpClient();
			HttpResponseMessage response = client.GetAsync(URI + "/subscribe").Result;
			Console.WriteLine(response.ToString());
		}

		public async Task<IList<Place>> GetPlacesAsync()
		{
			HttpClient client = new HttpClient();
			string response = await client.GetStringAsync(URI + "/places");
			List<Place> result = JsonSerializer.Deserialize<List<Place>>(response);
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

		public async Task AddPlaceReviewAsync(long id, ReviewItem review)
		{
			HttpClient client = new HttpClient();
			string reviewSerialized = JsonSerializer.Serialize(review);

			StringContent content = new StringContent(
				reviewSerialized,
				Encoding.UTF8,
				"application/json"
			);

			HttpResponseMessage response = await client.PostAsync(URI + $"/places/{id}/reviews", content);
			Console.WriteLine(response.ToString());
		}


	}
}