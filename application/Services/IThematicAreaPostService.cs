using application.DTOs.ThematicAreaPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Services
{
    public interface IThematicAreaPostService
    {
        Task<CreateThematicAreaPostResponse> CreateAsync(CreateThematicAreaPostRequest request);
        Task<int> GetAllThematicAreaPostCount();
        Task<IEnumerable<ThematicAreaPostResponse>> GetAllAsync();
        Task<int> DeleteByIdAsync(int id);
    }
}
