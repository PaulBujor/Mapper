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
		[Inject]
		IJSRuntime JSRuntime { get; set; }

		public void AddMarkerAsync(double longitude, double latitude)
		{
			JSRuntime.InvokeVoidAsync("mapBoxFunctions.addMarker", longitude, latitude);
		}

		public void InitMapAsync()
		{
			JSRuntime.InvokeVoidAsync("mapBoxFunctions.initMapBox");
		}

		public void SetJSRuntime(IJSRuntime jsRuntime)
		{
			JSRuntime = jsRuntime;
		}
	}
}
