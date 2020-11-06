using Client.Models;
using Client.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Data.Networking
{
	public class ClientImp : IServer
	{
		private RESTClient rest;
		private UDPListener listener;

		public ClientImp ()
		{
			rest = new RESTClient();
			listener = new UDPListener();
			//subscribe method to delegate
			var listenerThread = new Thread(listener.Run);
			listenerThread.Name = "UDP Listener";
			listenerThread.Start();
		}

		public async Task AddPlaceAsync(Place place)
		{
			await rest.AddPlaceAsync(place);
		}

		public async Task<IList<Place>> GetPlacesAsync()
		{
			return await rest.GetPlacesAsync();
		}
	}
}
