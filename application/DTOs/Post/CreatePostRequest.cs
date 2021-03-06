using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DTOs.Post
{
    public class CreatePostRequest
    {
        public string TitleTJ { get; set; }
        public string TitleEN { get; set; }
        public string DescriptionTJ { get; set; }
        public string DescriptionEN { get; set; }
        public IFormFile Image { get; set; }
        public List<IFormFile> AdditionalImages { get; set; }
    }
}
