using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataServer.Models
{
    [Serializable]
    public class Review
    {
        [Key]
        public long id { get; set; }
        [Required]
        public int rating { get; set; }
        [MaxLength(500)]
        public string comment { get; set; }
        [Required]
        public UserData addedBy { get; set; }
    }
}
