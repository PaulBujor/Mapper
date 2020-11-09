using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataServer
{
    //todo store places here, evt. will connect to database
    class Model
    {

        private Dictionary<long, Place> places;
        private int key;

        public Model()
        {
            key = 0;
            places = new Dictionary<long, Place>();
        }

        public List<Place> GetAllPlaces()
        {
            return places.Values.ToList();
        }

        public Place AddPlace(Place place)
        {
            places.Add(++key, place);
            place.Id = key;
            return place;
        }

        public void UpdatePlace(Place place)
        {
            places[place.Id] = place;
        }


        public void DeletePlace(long id)
        {
            places.Remove(id);
        }



    }
}
