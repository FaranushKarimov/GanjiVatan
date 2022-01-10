using application.DTOs.ThematicAreaPost;
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
            var thematicalAreaPostImage = new List<FileResponse>()
            {
                new()
                {
                    //FilePath = await _fileService.AddFileAsync(request.MainImage,FileTypes.)
                }
            };
            return thematicalAreaPost.ToCreateThematicAreaPostResponse();
        }
    }
}
