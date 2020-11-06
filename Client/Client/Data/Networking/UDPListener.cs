using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Data.Networking
{
	public class UDPListener
	{
		private UdpClient client;
		//add delegate

		public UDPListener()
		{
			client = new UdpClient(7000);
		}

		public void Run()
		{
			IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);
			while (true)
			{
				Byte[] receiveBytes = client.Receive(ref iPEndPoint);
				string message = Encoding.ASCII.GetString(receiveBytes);
				//invoke delegate
			}
		}
	}
}
