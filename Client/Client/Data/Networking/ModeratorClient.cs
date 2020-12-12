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

		public async Task<List<Report<Review>>> GetReviewReportsAsync()
		{
			HttpClient client = new HttpClient();
			string response = await client.GetStringAsync(URI + "/reports/reviews");
			return JsonSerializer.Deserialize<List<Report<Review>>>(response);
		}

		public async Task<List<Report<User>>> GetUserReportsAsync()
		{
			HttpClient client = new HttpClient();
			string response = await client.GetStringAsync(URI + "/reports/users");
			return JsonSerializer.Deserialize<List<Report<User>>>(response);
		}

		public async Task<List<User>> GetBannedUsersAsync()
		{
			HttpClient client = new HttpClient();
			string response = await client.GetStringAsync(URI + "/bannedUsers");
			return JsonSerializer.Deserialize<List<User>>(response);
		}

		public async Task RemovePlaceAsync(long placeId)
		{
			HttpClient client = new HttpClient();
			HttpResponseMessage response = await client.PatchAsync(URI + "/reports/places?placeId=" + placeId +"&action=remove", null);
			Console.WriteLine(response.ToString());
		}

		public async Task DismissPlaceReportAsync(long reportId)
		{
			HttpClient client = new HttpClient();
			HttpResponseMessage response = await client.PutAsync(URI + "/reports/places/dismissed?reportId=" + reportId, null);
			Console.WriteLine(response.ToString());
		}

		public async Task RemoveReviewAsync(long reviewId)
		{
			HttpClient client = new HttpClient();
			HttpResponseMessage response = await client.PatchAsync(URI + "/reports/reviews?reviewId=" + reviewId + "&action=remove", null);
			Console.WriteLine(response.ToString());
		}

		public async Task DismissReviewReportAsync(long reportId)
		{
			HttpClient client = new HttpClient();
			HttpResponseMessage response = await client.PutAsync(URI + "/reports/reviews/dismissed?reportId=" + reportId, null);
			Console.WriteLine(response.ToString());
		}

		public async Task BanUserAsync(long userId)
		{
			HttpClient client = new HttpClient();
			HttpResponseMessage response = await client.PatchAsync(URI + "/reports/users?userId=" + userId + "&action=ban", null);
			Console.WriteLine(response.ToString());
		}

		public async Task UnbanUserAsync(long userId)
		{
			HttpClient client = new HttpClient();
			HttpResponseMessage response = await client.PatchAsync(URI + "/reports/users?userId=" + userId + "&action=unban", null);
			Console.WriteLine(response.ToString());
		}

		public async Task DismissUserReportAsync(long reportId)
		{
			HttpClient client = new HttpClient();
			HttpResponseMessage response = await client.PutAsync(URI + "/reports/users/dismissed?reportId=" + reportId, null);
			Console.WriteLine(response.ToString());
		}
	}
}
