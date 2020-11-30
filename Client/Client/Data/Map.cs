﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;
using System.Threading;

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

        private static bool dataReady = false;

        public Map(IJSRuntime jsRuntime, IModel model)
        {
            this.jsRuntime = jsRuntime;
            this.model = model;
            addingMarkerMode = false;

            model.OnNewPlace += AddMarker;
            model.OnMapLoaded += DataReady;
        }

        public async Task InitMapAsync()
        {
            if (objRef == null)
                objRef = DotNetObjectReference.Create(this);
            await jsRuntime.InvokeVoidAsync("mapBoxFunctions.initMapBox", objRef);

            while (!dataReady)
                await Task.Delay(100);

            foreach (Place place in model.GetPlaces())
            {
               await AddMarkerAsync(place);
            }
        }

        public void DataReady()
		{
            dataReady = true;
		}

        public async Task AddMarkerAsync(Place place)
        {
            await jsRuntime.InvokeVoidAsync("mapBoxFunctions.addMarker", place.longitude, place.latitude, place.title, place.description, place.id);
        }

        public void AddMarker(Place place)
		{
            jsRuntime.InvokeVoidAsync("mapBoxFunctions.addMarker", place.longitude, place.latitude, place.title, place.description, place.id);

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
            //await AddMarkerAsync(newPlace); //line will be removed and place will be added when model gets it from broadcaster
            await removeTemporaryMarkerAsync();
            await model.AddPlaceAsync(newPlace);
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
        [JSInvokable("ReportPlace")]
        public async Task ReportPlace(long id)
        {
            Console.WriteLine(id);
           /* Report<Place> report = new Report<Place>
            {
                
            }*/
            //create report object
            //send it to model
        }

        [JSInvokable("GetPlaceDetails")]
        public async Task GetPlaceDetails(long id)
        {
            Console.WriteLine(id);
            Place place = model.GetPlaces().FirstOrDefault(p => p.id.Equals(id));
            await jsRuntime.InvokeVoidAsync("mapBoxFunctions.addReviewLite", place.reviews.GetRating());
        }

        public async Task GetReviewFull()
        { 

        }
    }
}
