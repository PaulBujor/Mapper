using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace DataServer
{
	class Program
	{

		static void Main(string[] args)
		{
			//existing used ports by the system
			int accountPort = 7020;
			int moderatorPort = 7010;
			int logicServerPort = 7000;
			int reportingPort = 7030;
			List<int> ports = new List<int> { moderatorPort, logicServerPort, accountPort, reportingPort };
			//add more as needed

			Model model = new Model();

			Console.WriteLine("Starting server...");

			//start port listeners for every port, each has its own thread
			foreach (int port in ports)
			{
				Server server = new Server(IPAddress.Parse("127.0.0.1"), port, model);
				Console.WriteLine($"Starting listener for port {port}");
				var serverThread = new Thread(server.StartListening);
				serverThread.Start();
			}

			Console.WriteLine("Server started...");
		}
	}
}
