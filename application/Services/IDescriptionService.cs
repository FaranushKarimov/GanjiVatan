using application.DTOs.Description;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Services
{
    public interface IDescriptionService
    {
        Task<CreateDescriptionResponce> CreateAsync(CreateDescriptionRequest request);
        Task<IEnumerable<DescriptionResponce>> GetAllAsync();
        Task<int> DeleteByIdAsync(int id);
        Task<DescriptionResponce> GetById(int id);
    }
}
