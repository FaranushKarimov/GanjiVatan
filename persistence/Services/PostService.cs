using application.DTOs.Post;
using application.Extensions;
using application.Services;
using Microsoft.EntityFrameworkCore;
using persistence.Contexts;
using System;
using System.Collections.Generic;
using System.IO;
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
            //for (int i = 0; i < request.AdditionalImages.Count(); ++i)
            //{
            //    post.AdditionalImagePath[i] = await _fileService.AddFileAsync(request.AdditionalImages[i], nameof(domain.Entities.Post));
            //}
            post.ImagePath = imagePath;
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return post.ToCreatePostResponce();
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
                return default;
            _fileService.DeleteFile(post.ImagePath);
            _context.Remove(post);
            await _context.SaveChangesAsync();
            return post.Id;
        }

        public async Task<IEnumerable<PostResponce>> GetAllAsync()
        {
            return await _context.Posts.OrderByDescending(x => x.Id).Select(x => x.ToPostResponce()).ToListAsync();
        }

        public async Task<int> GetAllPostsCount()
        {
            return await _context.Posts.CountAsync();
        }

        public async Task<PostResponce> GetByIdAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            return post?.ToPostResponce();
        }

        public async Task<UpdatePostResponce> UpdateAsync(UpdatePostRequest request)
        {
            var post = await _context.Posts.FindAsync(request.Id);
            request.ToPost(ref post);
            if (request.Image != null)
            {
                _fileService.DeleteFile(post.ImagePath);
                var imagePath = await _fileService.AddFileAsync(request.Image, nameof(domain.Entities.Post));
                post.ImagePath = imagePath;
            }
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
            return post.ToUpdatePostResponce();
        }
    }
}
