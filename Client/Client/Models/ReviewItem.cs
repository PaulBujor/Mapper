using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Data
{
    public class ReviewItem
    {
        public long id;
        public User user { get; set; }
        public int rating { get; set; }
        public string comment { get; set; }
    }
}
