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

		public void AddMarkerAsync(int longitude, int latitude)
		{
			throw new NotImplementedException();
		}

		public void InitMapAsync()
		{
			JSRuntime.InvokeVoidAsync("mapBoxFunctions.initMapBox");
		}

		public void SetJSRuntime(IJSRuntime jsRuntime)
		{
			//JSRuntime = jsRuntime;
		}
	}
}
