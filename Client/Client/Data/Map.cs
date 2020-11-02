using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Client.Data
{
	public class Map : IMap
	{
		private readonly IJSRuntime jsRuntime;

		public Map(IJSRuntime jsRuntime)
		{
			this.jsRuntime = jsRuntime;
			InitMapAsync();
		}

		public async Task AddMarkerAsync(double longitude, double latitude)
		{
			await jsRuntime.InvokeVoidAsync("mapBoxFunctions.addMarker", longitude, latitude);
		}

		public async Task InitMapAsync()
		{
			await jsRuntime.InvokeVoidAsync("mapBoxFunctions.initMapBox");
		}
	}
}
