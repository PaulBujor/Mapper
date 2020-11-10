using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Data.Networking
{
	public class UDPListener
	{
		private UdpClient client;
		public delegate void UDPDelegate(Place place);
		public UDPDelegate OnNewPlace;
		public UDPDelegate OnDeletePlace;
		public UDPDelegate OnUpdatePlace;

		public UDPListener()
		{
			client = new UdpClient(15630);
		}

		public void Run()
		{
			IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);
			while (true)
			{
				Byte[] receiveBytes = client.Receive(ref iPEndPoint);
				string message = Encoding.ASCII.GetString(receiveBytes);
				PlaceTask task = JsonSerializer.Deserialize<PlaceTask>(message);
				Console.WriteLine("received task: " + task.taskName);
				ProcessTask(task);
			}
		}

		private void ProcessTask(PlaceTask task)
		{
			switch (task.taskName)
			{
				case "addPlace":
					OnNewPlace?.Invoke(task.place);
					break;
				case "updatePlace":
					OnUpdatePlace?.Invoke(task.place);
					break;
				case "deletePlace":
					OnDeletePlace?.Invoke(task.place);
					break;
				default:
					Console.WriteLine("¯\\_(ツ)_/¯");
					break;
			}
		}
	}
}
