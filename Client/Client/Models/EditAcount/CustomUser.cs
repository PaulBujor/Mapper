using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Client.Models
{
    public class CustomUser
    {
        
        [NotNull]
        [StringLength(16,ErrorMessage = "1 to 16 characters allowed for username", MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "For username only alphabet and numbers allowed.")]
       
        public string username { get; set; }
        
       [NotNull]
        [EmailAddress]
       
        public string email { get; set; }
        public int auth { get; set; }
        [NotNull]
        [StringLength(16,ErrorMessage = "1 to 16 characters allowed for name", MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter alphabet only. ")] 
        public string firstname { get; set; }
       
        [NotNull]
        [StringLength(16,ErrorMessage = "1 to 16 characters allowed for last name", MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter alphabet only.")] 
        public string lastname { get; set; }
        
        public string password { get; set; }
        public long id { get; set; }

    }
}