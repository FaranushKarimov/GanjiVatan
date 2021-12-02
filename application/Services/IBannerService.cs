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
        Task<int> DeleteByIdAsync(int id);
        Task<IEnumerable<BannerResponce>> GetAllAsync();
        Task<BannerResponce> GetbyIdAsync(int id);
        Task<UpdateBannerResponce> UpdateAsync(int id, UpdateBannerRequest request);
    }
}
