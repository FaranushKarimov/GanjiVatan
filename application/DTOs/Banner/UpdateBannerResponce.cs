using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DTOs.Banner
{
    public class UpdateBannerResponce
    {
        public int Id { get; set; }
        public string DescriptionBannerTJ { get; set; }
        public string DescriptionBannerEN { get; set; }
        public string ImagePath { get; set; }
    }
}
