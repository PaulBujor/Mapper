using DataServer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataServer.Models
{
	[Serializable]
	public class ReviewLite
	{
        [Key]
        public long id { get; set; }
        [Required]
        public int rating { get; set; }
        [MaxLength(500)]
        public string comment { get; set; }
        [Required]
        public UserData addedBy { get; set; }

        public ReviewLite() { }

        public ReviewLite(Review review)
		{
            id = review.id;
            rating = review.rating;
            comment = review.comment;
            addedBy = new UserData(review.addedBy);
		}
    }
}
