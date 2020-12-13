using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataServer.Models
{
    [Serializable]
    public class Place
    {
        [Key]
        public long id { get; set; }
        [Required]
        public double longitude { get; set; }
        [Required]
        public double latitude { get; set; }
        [Required, MaxLength(100)]
        public string title { get; set; }
        [MaxLength(500)]
        public string description { get; set; }
        public List<Review> reviews { get; set; }
        public IList<User> users { get; set; }
        [Required]
        public UserData addedBy { get; set; }

        public Place()
        {
        }

        public Place(double longitude, double latitude, string title, string description)
        {
            this.longitude = longitude;
            this.latitude = latitude;
            this.title = title;
            this.description = description;
            reviews = new List<Review>();
        }

        public Place(PlaceForDeserialization place)
        {
            id = (long)place.id;
            longitude = place.longitude;
            latitude = place.latitude;
            title = place.title;
            description = place.description;
            reviews = place.reviews;
        }
        public void AddReview(Review review)
        {
            reviews.Add(review);
        }

        public double GetRating()
        {
            long score = 0;
            foreach (Review item in reviews)
            {
                score += item.rating;
            }
            return (double)score / reviews.Count;
        }

        public List<Review> GetReviews()
        {
            return reviews;
        }
    }
}
