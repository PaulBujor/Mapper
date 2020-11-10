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

            //for demo
            InitPlace();
        }

        private void InitPlace()
		{
            Place reitan = new Place()
            {
                title = "Reitan",
                description = "Heaven",
                longitude = 9.795995847440167,
                latitude = 55.83663617092108
            };
            AddPlace(reitan);
		}

        public List<Place> GetAllPlaces()
        {
            return places.Values.ToList();
        }

        public Place AddPlace(Place place)
        {
            places.Add(++key, place);
            place.id = key;
            return place;
        }

        public void UpdatePlace(Place place)
        {
            places[place.id] = place;
        }


        public void DeletePlace(long id)
        {
            places.Remove(id);
        }



    }
}
