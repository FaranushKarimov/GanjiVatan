using application.DTOs.Banner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Services
{
    public interface IBannerService
    {
        Task<CreateBannerResponce> CreateAsync(CreateBannerRequest request);
        Task<IEnumerable<BannerResponce>> GetAllAsync();     
    }
}
