using DataServer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataServer.Models
{
    [Serializable]
	public class PlaceLite
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
        public List<ReviewLite> reviews { get; set; }
        [Required]
        public UserData addedBy { get; set; }

        public PlaceLite() { }

        public PlaceLite(Place place)
		{
            id = place.id;
            longitude = place.longitude;
            latitude = place.latitude;
            title = place.title;
            description = place.description;
            reviews = new List<ReviewLite>();
            foreach (Review review in place.reviews)
                AddReview(new ReviewLite(review));
            addedBy = new UserData(place.addedBy);
		}

        public void AddReview(ReviewLite review)
        {
            reviews.Add(review);
        }

        public double GetRating()
        {
            long score = 0;
            foreach (ReviewLite item in reviews)
            {
                score += item.rating;
            }
            return (double)score / reviews.Count;
        }

        public List<ReviewLite> GetReviews()
        {
            return reviews;
        }
    }
}
