using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataServer.Models
{
    public class User
    {
        [Key]
        public long id { get; set; } //we might have to make this a unique id as well, used for reporting users, since username will be string
        [Required, MaxLength(200)]
        public string email { get; set; }
        [Required] //Should it be unique
        public string username { get; set; } //username could be changed in time, it just has to be unique
        [Required]
        public string password { get; set; }
        [Required]
        public int auth { get; set; }
        //0 banned
        //1 regular user
        //2 moderator
        //3 admin

		public string firstName { get; set; }
		public string lastName { get; set; }
		public List<Place> savedPlaces { get; set; }
	}
}
