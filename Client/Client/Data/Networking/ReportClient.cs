using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Data.Networking
{
    public class ReportClient
    {

        private string URI = "http://127.0.0.1:8080";
   

		public async Task ReportPlaceAsync(Report<Place> report)
		{
			HttpClient client = new HttpClient();
			string reportSerialized = JsonSerializer.Serialize(report);

			StringContent content = new StringContent(
				reportSerialized,
				Encoding.UTF8,
				"application/json"
			);

			HttpResponseMessage response = await client.PostAsync(URI + "/reports/places", content);
			Console.WriteLine(response.ToString());
		}

		public async Task ReportUserAsync(Report<User> report)
		{
			HttpClient client = new HttpClient();
			string reportSerialized = JsonSerializer.Serialize(report);

			StringContent content = new StringContent(
				reportSerialized,
				Encoding.UTF8,
				"application/json"
			);

			HttpResponseMessage response = await client.PostAsync(URI + "/reports/users", content);
			Console.WriteLine(response.ToString());
		}

		public async Task ReportReviewAsync(Report<Review> report)
		{
			HttpClient client = new HttpClient();
			string reportSerialized = JsonSerializer.Serialize(report);

			StringContent content = new StringContent(
				reportSerialized,
				Encoding.UTF8,
				"application/json"
			);

			HttpResponseMessage response = await client.PostAsync(URI + "/reports/reviews", content);
			Console.WriteLine(response.ToString());
		}

	}
}
