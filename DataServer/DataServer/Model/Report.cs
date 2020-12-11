using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataServer.Models
{
    [Serializable]
    public class Report<T>
    {
        [Key]
        public long reportId { get; set; }
        [Required] //??
        public T reportedItem { get; set; }
        [MaxLength(200)] //??
        public string reportedClass { get; set; }
        //Should resolved have an attribute??
        public bool resolved { get; set; }
        [MaxLength(100)]
        public string category { get; set; }
        [MaxLength(500)]
        public string description { get; set; }

        public Report()
        {
        }
    }
}
