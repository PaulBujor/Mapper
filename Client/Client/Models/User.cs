using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Client.Data;
using Microsoft.JSInterop;


namespace Client.Models
{
    public class User
    {

        
        [Required]
        [StringLength(16)]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "For username only alphabet and numbers allowed.")]
       
        public string username { get; set; }
        [Required]
        [ValidPassword]
        [StringLength(16,ErrorMessage = "Password must be between 8 to 16 characters long",MinimumLength = 8)]
        public string password { get; set; }
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
        public long id { get; set; }

        public List<Place> savedPlaces { get; set; }

        
        
       
        [Compare("password", ErrorMessage = "Passwords must match.")]
        public string confirmpassword { get; set; }

        
        public class ValidPassword : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {

                int counter = 0;
                string tmpString = value.ToString();
                Console.WriteLine(tmpString);
              
                if (Regex.IsMatch(tmpString, "[A-Z]",RegexOptions.ECMAScript))
                {
                    counter++;
                }
                if (Regex.IsMatch(tmpString, "[0-9]"))
                {
                    counter++;
                   
                }
                if (Regex.IsMatch(tmpString, "[!-)]"))
                {
                    counter++;
                    
                }
                Console.WriteLine(counter.ToString());
                if (counter < 3)
                {
                    return new ValidationResult("Password too weak, must contain a capital letter, a number and a special character");
                }
                return ValidationResult.Success;
            }

            
            
            
        }
     
              
        }


    }
