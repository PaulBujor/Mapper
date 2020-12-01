using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Client.Data.Networking.UDPListener;

namespace Client.Networking
{
	public interface IServer
	{
		Task<IList<Place>> GetPlacesAsync();

		Task AddPlaceAsync(Place place);

		Task RemovePlaceAsync(long placeId);

		Task DismissReportAsync(long reportId);
	}
}
