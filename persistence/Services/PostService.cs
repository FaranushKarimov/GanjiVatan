using application.DTOs.Post;
using application.Extensions;
using application.Services;
using persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persistence.Services
{
    public class PostService : IPostSerivce
    {
        private readonly VatanDbContext _context;
        private readonly IFileService _fileService;
        public PostService(VatanDbContext context,IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<CreatePostResponce> CreateAsync(CreatePostRequest request)
        {
            var post = request.ToPost();
            var imagePath = await _fileService.AddFileAsync(request.Image, nameof(domain.Entities.Post));
            post.ImagePath = imagePath;
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return post.ToCreatePostResponce();
        }
    }
}
