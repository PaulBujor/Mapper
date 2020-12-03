using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Data
{
	public interface IMap
	{
		Task InitMapAsync();
		Task InitMapMarkerAsync(long id);
		Task AddMarkerAsync(Place place);

		Task SetTemporaryMarkerAsync();

		Task MapClickedAsync(double longitude, double latitude);

		void ChangeAddingMarkerMode();

		Task CreatePlace(PlaceData placeData);
	}
}
