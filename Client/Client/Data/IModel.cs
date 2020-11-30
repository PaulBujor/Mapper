using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Client.Data.Model;

namespace Client.Data
{
	public abstract class IModel
	{
		public delegate void MapChange(Place place);
		public MapChange OnNewPlace;

		public delegate void MapLoaded();
		public MapLoaded OnMapLoaded;

		public abstract Task AddPlaceAsync(Place place);

		public abstract IList<Place> GetPlaces();

		public abstract Task<List<Report<Place>>> GetPlaceReportsAsync();

		public abstract Task RemovePlaceAsync(long placeId);

		public abstract Task DismissPlaceReportAsync(long reportId);

	}
}
