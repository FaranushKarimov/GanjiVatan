using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace domain.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string TitleTJ { get; set; }
        public string TitleEN { get; set; }
        public string DescriptionTJ { get; set; }
        public string DescriptionEN { get; set; }
        public string ImagePath { get; set; }
        //public List<string> AdditionalImagePath { get; set; }
        public Banner Banner { get; set; }
    }
}
