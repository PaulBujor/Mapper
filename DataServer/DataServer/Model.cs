using DataServer.Models;
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
        private Dictionary<String, User> users;
        private int key;

        public Model()
        {
            key = 0;
            places = new Dictionary<long, Place>();
            users = new Dictionary<string, User>();

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

		internal bool AuthroizeUser(User user)
		{
            User check = null;
            if (users.TryGetValue(user.username, out check))
                return check.auth >= 2;
            else
                return false;
		}
	}
}
