﻿using Microsoft.AspNetCore.Components;
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
		private DotNetObjectReference<Map> objRef;
		//store List<Place> here, add markers on InitMapAsync

		public Map(IJSRuntime jsRuntime)
		{
			this.jsRuntime = jsRuntime;
		}

		public async Task AddMarkerAsync(double longitude, double latitude)
		{
			await jsRuntime.InvokeVoidAsync("mapBoxFunctions.addMarker", longitude, latitude);
		}

		public async Task InitMapAsync()
		{

			objRef = DotNetObjectReference.Create(this);
			await jsRuntime.InvokeVoidAsync("mapBoxFunctions.initMapBox", objRef);
		}

		[JSInvokable]
		public async Task MapClickedAsync(double longitude, double latitude)
		{
			Console.WriteLine($"Click at lng: {longitude}; lat: {latitude}");
		}
	}
}
