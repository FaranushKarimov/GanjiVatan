using System;
using System.Collections.Generic;
using System.Text;

namespace domain.Entities
{
    public class Banner
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int? PostId { get; set; } 
        public string DescriptionTJ { get; set; }
        public string DescriptionEN { get; set; }
        public Post Post { get; set; }
    }
}
