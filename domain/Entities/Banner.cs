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
        public string Description { get; set; }
        public Post Post { get; set; }
    }
}
