using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entities
{
    public class ThematicAreaPost
    {
        public int Id { get; set; }
        public string TitleTJ { get; set; }
        public string TitleEN { get; set; }
        public string DescriptionTJ { get; set; }
        public string DescriptionEN { get; set; }
        public List<File> Files { get; set; }

    }
}
