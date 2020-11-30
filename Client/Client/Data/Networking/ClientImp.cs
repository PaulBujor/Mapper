﻿using Client.Models;
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
		private ModeratorClient _moderator;
		private ReportClient _report;
		public UDPListener listener;

		public ClientImp ()
		{
			_place = new PlaceClient();
			_moderator = new ModeratorClient();
			_report = new ReportClient();
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

		public async Task ReportPlace(Report<Place> report)
		{
			await _report.ReportPlaceAsync(report);
		}

		public async Task<List<Report<Place>>> GetPlaceReportsAsync()
		{
			return await _moderator.GetPlaceReportsAsync();
		}
	}
}
