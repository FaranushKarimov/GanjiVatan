using application.DTOs.ThematicAreaPost;
using application.Extensions;
using application.Services;
using domain.Entities;
using Microsoft.EntityFrameworkCore;
using persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persistence.Services
{
    public class ThematicAreaPostService : IThematicAreaPostService
    {
        private readonly VatanDbContext _context;
        private readonly IFileService _fileService;
        public ThematicAreaPostService(VatanDbContext context,IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }
        public async Task<CreateThematicAreaPostResponse> CreateAsync(CreateThematicAreaPostRequest request)
        {
            var thematicalAreaPost = request.ToThematicAreaPost();
            var thematicalAreaPostImage = new List<File>()
            {
                new()
                {
                    Path = await _fileService.AddFileAsync(request.MainImage, nameof(domain.Entities.ThematicAreaPost)),
                    IsMain = true
                }
            };
            if(request.Images != null)
            {
                thematicalAreaPostImage.AddRange(request.Images.Select(x => new File
                {
                    Path = _fileService.AddFileAsync(x,nameof(domain.Entities.ThematicAreaPost)).Result,
                    IsMain = false
                }));
            }
            thematicalAreaPost.Files = thematicalAreaPostImage;
            await _context.ThematicAreaPosts.AddAsync(thematicalAreaPost);
            await _context.SaveChangesAsync();
            return thematicalAreaPost.ToCreateThematicAreaPostResponse();
        }

        public async Task<IEnumerable<ThematicAreaPostResponse>> GetAllAsync()
        {
           return await _context.ThematicAreaPosts.Include(x => x.Files).Select(x =>
           new ThematicAreaPostResponse
           {
               Id = x.Id,
               TitleEN = x.TitleEN,
               TitleTJ = x.TitleTJ,
               DescriptionEN = x.DescriptionEN,
               DescriptionTJ = x.DescriptionTJ,
               Files = x.Files.Select(x => new FileResponse
               {
                   Id = x.Id,
                   FilePath = x.Path,
                   IsMain = x.IsMain
               }).ToList()
           }).ToListAsync();
        }

        public async Task<int> GetAllThematicAreaPostCount()
        {
            return await _context.ThematicAreaPosts.CountAsync();
        }

    }
}
