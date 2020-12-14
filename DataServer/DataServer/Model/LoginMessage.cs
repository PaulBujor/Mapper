using System.ComponentModel.DataAnnotations;

namespace DataServer.Models
{
    public class LoginMessage
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}