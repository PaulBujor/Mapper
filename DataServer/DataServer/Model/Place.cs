using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public IList<User> savedBy { get; set; }
        [Required]
        public User addedBy { get; set; }

        public bool removed { get; set; }

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

		public Place(PlaceLite place, User addedBy)
		{
			this.id = place.id;
			this.longitude = place.longitude;
			this.latitude = place.latitude;
			this.title = place.title;
			this.description = place.description;
            this.reviews = new List<Review>();
            this.savedBy = new List<User>();
			this.addedBy = addedBy;
		}

        public Place(PlaceLite place, User addedBy, List<Review> fullReviews)
        {
            this.id = place.id;
            this.longitude = place.longitude;
            this.latitude = place.latitude;
            this.title = place.title;
            this.description = place.description;
            this.reviews = fullReviews;
            this.savedBy = new List<User>();
            this.addedBy = addedBy;
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
