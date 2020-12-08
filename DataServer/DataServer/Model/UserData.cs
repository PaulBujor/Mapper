using System.ComponentModel.DataAnnotations;

namespace DataServer.Models
{
    public class UserData
    {
        [Key]
        public long userId { get; set; }
        [Required]
        public string username { get; set; }

        public UserData() { }
    }
}