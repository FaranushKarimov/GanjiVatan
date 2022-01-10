using application.DTOs.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Services
{
    public interface IPostSerivce
    {
        Task<CreatePostResponce> CreateAsync(CreatePostRequest request);
        Task<int> DeleteByIdAsync(int id);
        Task<IEnumerable<PostResponce>> GetAllAsync();
        Task<UpdatePostResponce> UpdateAsync(UpdatePostRequest request);
        Task<PostResponce> GetByIdAsync(int id);
        Task<int> GetAllPostsCount();
    }
}
