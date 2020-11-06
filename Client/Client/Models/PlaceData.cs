using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Client.Models
{
    public class PlaceData
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        public void Reset()
        {
            Title = "";
            Description = "";
        }

    }
}
