using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace application.DTOs.Banner
{
    public class CreateBannerResponce
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int? PostId { get; set; }
        public string DescriptionBannerTJ { get; set; }
        public string DescriptionBannerEN { get; set; }
    }
}
