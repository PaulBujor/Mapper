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

		public abstract Task AddPlaceAsync(Place place);

		public abstract IList<Place> GetPlaces();
	}
}
