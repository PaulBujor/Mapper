using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
    public class CustomUser
    {
        [Required]
        [StringLength(16)]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "For username only alphabet and numbers allowed.")]
       
        public string username { get; set; }
        
        [Required]
        [EmailAddress]
       
        public string email { get; set; }
        public int auth { get; set; }
        [Required]
        [StringLength(16)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter alphabet only. ")] 
        public string firstname { get; set; }
        [Required]
        [StringLength(16)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter alphabet only.")] 
        public string lastname { get; set; }
        
        public string password { get; set; }

    }
}