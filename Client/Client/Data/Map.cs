using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;


namespace Client.Data
{
    public class Map : IMap
    {
        private readonly IJSRuntime jsRuntime;
        private readonly IModel model;
        private DotNetObjectReference<Map> objRef;

        private bool addingMarkerMode;

        private double currentLongitude = 0;
        private double currentLatitude = 0;

        public Map(IJSRuntime jsRuntime, IModel model)
        {
            this.jsRuntime = jsRuntime;
            this.model = model;
            addingMarkerMode = false;
        }

        public async Task InitMapAsync()
        {
            if (objRef == null)
                objRef = DotNetObjectReference.Create(this);
            await jsRuntime.InvokeVoidAsync("mapBoxFunctions.initMapBox", objRef);

            foreach (Place place in model.GetPlaces())
            {
               await AddMarkerAsync(place);
            }
        }

        public async Task AddMarkerAsync(Place place)
        {
            await jsRuntime.InvokeVoidAsync("mapBoxFunctions.addMarker", place.Longitude, place.Latitude, place.Title, place.Description);
        }


        public void ChangeAddingMarkerMode()
        {
            addingMarkerMode = !addingMarkerMode;
        }

        public async Task SetTemporaryMarkerAsync()
        {
            await jsRuntime.InvokeVoidAsync("mapBoxFunctions.setTemporaryMarker", currentLongitude, currentLatitude);
        }

        public async Task removeTemporaryMarkerAsync()
        {
            await jsRuntime.InvokeVoidAsync("mapBoxFunctions.removeTemporaryMarker");
        }


        public async Task CreatePlace(PlaceData placeData)
        {
            Place newPlace = new Place(currentLongitude, currentLatitude, placeData.Title, placeData.Description);
            await AddMarkerAsync(newPlace);
            await removeTemporaryMarkerAsync();
            model.AddPlace(newPlace);
        }

        [JSInvokable("MapClickAsync")]
        public async Task MapClickedAsync(double longitude, double latitude)
        {
            currentLatitude = latitude;
            currentLongitude = longitude;

            if (addingMarkerMode)
            {
                await SetTemporaryMarkerAsync();
            }
        }

        [JSInvokable("UpdateCoordinates")]
        public void UpdateCoordinates(double longitude, double latitude)
        {
            currentLatitude = latitude;
            currentLongitude = longitude;
        }
    }
}
