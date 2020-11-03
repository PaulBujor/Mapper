using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Data
{
	public interface IMap
	{
		Task InitMapAsync();
		Task AddMarkerAsync(double longitude, double latitude);

		Task MapClickedAsync(double longitude, double latitude);

		void ChangeAddingMarkerMode();
	}
}
