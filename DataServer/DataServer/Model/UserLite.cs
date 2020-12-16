using DataServer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataServer.Models
{
	class UserLite
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

        public string firstname { get; set; }
        public string lastname { get; set; }
        public List<PlaceLite> savedPlaces { get; set; }

        public UserLite(User user)
		{
            id = user.id;
            email = user.email;
            username = user.username;
            password = user.password;
            auth = user.auth;
            firstname = user.firstname;
            lastname = user.lastname;
            savedPlaces = new List<PlaceLite>();
            foreach(Place place in user.savedPlaces)
			{
                savedPlaces.Add(new PlaceLite(place));
			}
		}
    }
}
