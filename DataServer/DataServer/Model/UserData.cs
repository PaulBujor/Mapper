using System.ComponentModel.DataAnnotations;
using System;

namespace DataServer.Models
{
    [Serializable]
    public class UserData
    {
        [Key]
        public long userId { get; set; }
        [Required]
        public string username { get; set; }

        public UserData() { }
        public UserData(User addedBy) {
            userId = addedBy.id;
            username = addedBy.username;
        }
    }
}