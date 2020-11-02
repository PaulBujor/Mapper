using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Data
{
	public interface IMap
	{
		void SetJSRuntime(IJSRuntime jSRuntime);
		void InitMapAsync();
		void AddMarkerAsync(double longitude, double latitude);
	}
}
