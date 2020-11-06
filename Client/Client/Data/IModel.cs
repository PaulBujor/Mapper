using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Data
{
	public interface IModel
	{
		void AddPlace(Place place);

		List<Place> GetPlaces();
	}
}
