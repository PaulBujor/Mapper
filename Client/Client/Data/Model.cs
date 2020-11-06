using Client.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Data
{
	public class Model : IModel
	{
		private List<Place> places;

		public Model()
		{
			places = new List<Place>();
		}

		public void AddPlace(Place place)
		{
			places.Add(place);
		}

		public List<Place> GetPlaces()
		{
			return places;
		}
	}
}
