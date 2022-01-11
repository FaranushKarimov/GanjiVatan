using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entities
{
    public class ThematicAreaPost
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Текст не может быть меньше 3 или больше 50")]
        public string TitleTJ { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Текст не может быть меньше 3 или больше 50")]
        public string TitleEN { get; set; }
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Текст не может быть меньше 3 или больше 50")]
        public string DescriptionTJ { get; set; }
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Текст не может быть меньше 3 или больше 50")]
        public string DescriptionEN { get; set; }
        public List<File> Files { get; set; }

    }
}
