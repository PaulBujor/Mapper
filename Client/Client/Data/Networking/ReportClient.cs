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
			string placeSerialized = JsonSerializer.Serialize(report);

			StringContent content = new StringContent(
				placeSerialized,
				Encoding.UTF8,
				"application/json"
			);

			HttpResponseMessage response = await client.PostAsync(URI + "/places", content);
			Console.WriteLine(response.ToString());
		}

	}
}
