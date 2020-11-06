using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Networking
{
	public interface IServer
	{
		Task<IList<Place>> GetPlacesAsync();

		Task AddPlaceAsync(Place place);
	}
}
