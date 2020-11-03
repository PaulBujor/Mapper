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
		private DotNetObjectReference<Map> objRef;

		private bool addingMarkerMode;
		//store List<Place> here, add markers on InitMapAsync

		public Map(IJSRuntime jsRuntime)
		{
			this.jsRuntime = jsRuntime;
			addingMarkerMode = false;
		}

		public async Task AddMarkerAsync(double longitude, double latitude)
		{
			await jsRuntime.InvokeVoidAsync("mapBoxFunctions.addMarker", longitude, latitude);
		}

		public async Task InitMapAsync()
		{
			if (objRef == null)
				objRef = DotNetObjectReference.Create(this);
			await jsRuntime.InvokeVoidAsync("mapBoxFunctions.initMapBox", objRef);
		}

		[JSInvokable("MapClickAsync")]
		public async Task MapClickedAsync(double longitude, double latitude)
		{
			Console.WriteLine($"Click at lng: {longitude}; lat: {latitude}");
			if (addingMarkerMode)
			{
				AddMarkerAsync(longitude, latitude);
			}
			
		}

		public void ChangeAddingMarkerMode()
		{
			addingMarkerMode = !addingMarkerMode;
		}

	
	}
}
