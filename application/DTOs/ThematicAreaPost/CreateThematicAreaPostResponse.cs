using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DTOs.ThematicAreaPost
{
    public class CreateThematicAreaPostResponse
    {
        public int Id { get; set; }
        public string TitleTJ { get; set; }
        public string TitleEN { get; set; }
        public string DescriptionTJ { get; set; }
        public string DescriptionEN { get; set; }

    }
}
