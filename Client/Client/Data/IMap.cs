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

		Task InitSavedPlacesAsync(List<Place> places);

		Task SetTemporaryMarkerAsync();

		Task MapClickedAsync(double longitude, double latitude);

		void ChangeAddingMarkerMode();

		bool GetAddingMarkerMode();

		Task CreatePlace(PlaceData placeData);
	}
}
