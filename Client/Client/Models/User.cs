using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
    public class User
    {
       
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        public int auth { get; set; }
    }
}