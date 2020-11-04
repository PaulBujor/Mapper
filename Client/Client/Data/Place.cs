using System.Text.Json.Serialization;

namespace Client.Data
{
    public class Place
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string MarkerName { get; set; }
        public string Description { get; set; }
    }
}