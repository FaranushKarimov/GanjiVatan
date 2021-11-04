using application.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace application.Services
{
    public interface ICategoryService
    {
        Task<CreateCategoryResponce> CreateAsync(CreateCategoryRequest request);
        Task<IEnumerable<CategoryResponce>> GetAllAsync();
        Task<UpdateCategoryResponce> UpdateAsync(int id,UpdateCategoryRequest request);
        Task<int> DeleteByIdAsync(int id);
    }
}
