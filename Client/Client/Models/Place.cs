using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Models
{
    public class Place
    {

        public Place(double longitude, double latitude, Popup popup)
        {
            Longitude = longitude;
            Latitude = latitude;
            this.popup = popup;
        }

        public double Longitude { get; set; }
        public double Latitude { get; set; }
        private Popup popup;

        public Popup GetPopup()
        {
            return popup;
        }


    }
}
