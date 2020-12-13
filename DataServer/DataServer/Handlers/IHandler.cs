using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataServer.Handlers
{
	interface IHandler
	{
		public Task Start();
	}
}
