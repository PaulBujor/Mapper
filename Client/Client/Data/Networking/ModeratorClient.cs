using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client.Data.Networking
{
	public class ModeratorClient
	{
		private string URI = "http://127.0.0.1:9090";

		public async Task<List<Report<Place>>> GetPlaceReportsAsync()
		{
			HttpClient client = new HttpClient();
			string response = await client.GetStringAsync(URI + "/reports/places");
			return JsonSerializer.Deserialize<List<Report<Place>>>(response);
		}

		public async Task RemovePlaceAsync(long placeId)
		{
			HttpClient client = new HttpClient();
			HttpResponseMessage response = await client.PatchAsync(URI + "/reports/places/" + placeId +"?action=remove", null);
			Console.WriteLine(response.ToString());
		}

		public async Task DismissReportAsync(long reportId)
		{
			HttpClient client = new HttpClient();
			HttpResponseMessage response = await client.PatchAsync(URI + "/reports/" + reportId + "?action=dismiss", null);
			Console.WriteLine(response.ToString());
		}
	}
}
