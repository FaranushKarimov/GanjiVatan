using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DTOs.Banner
{
    public class CreateBannerRequest
    {
        public IFormFile Image { get; set; }
        public int? PostId { get; set; }
        public string DescriptionBannerTJ { get; set; }
        public string DescriptionBannerEN { get; set; }
       
    }
}
