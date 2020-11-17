using Client.Models;
using Client.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Client.Data.Networking.UDPListener;

namespace Client.Data.Networking
{
	public class ClientImp : IServer
	{
		private PlaceClient _place;
		public UDPListener listener;

		public ClientImp ()
		{
			_place = new PlaceClient();
			listener = new UDPListener();

			var subscriberThread = new Thread(_place.Subscribe);
			subscriberThread.Name = "Subscriber";
			subscriberThread.Start();

			//new Thread(() => rest.SubscribeAsync()).Start();
			var listenerThread = new Thread(listener.Run);
			listenerThread.Name = "UDP Listener";
			listenerThread.Start();
		}

		public async Task AddPlaceAsync(Place place)
		{
			await _place.AddPlaceAsync(place);
		}

		public async Task<IList<Place>> GetPlacesAsync()
		{
			return await _place.GetPlacesAsync();
		}

		public UDPDelegate GetDelegate(string delegateName)
		{
			switch (delegateName)
			{
				case "addPlace":
					return listener.OnNewPlace;
					break;
				case "updatePlace":
					return listener.OnUpdatePlace;
					break;
				case "deletePlace":
					return listener.OnDeletePlace;
					break;
				default:
					throw new ArgumentException("Delegate not found!");
					break;
			}
		}
	}
}
