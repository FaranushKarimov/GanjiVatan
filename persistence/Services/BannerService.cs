using application.DTOs.Banner;
using application.Extensions;
using application.Services;
using Microsoft.EntityFrameworkCore;
using persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persistence.Services
{
    public class BannerService : IBannerService
    {
        private readonly VatanDbContext _context;
        private readonly IFileService _fileService;

        public BannerService(VatanDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }
        public async Task<CreateBannerResponce> CreateAsync(CreateBannerRequest request)
        {
            var bannerName = request.ToBanner();
            var imagePath = await _fileService.AddFileAsync(request.Image, nameof(domain.Entities.Banner));
            bannerName.ImagePath = imagePath;
            await _context.Banners.AddAsync(bannerName);
            await _context.SaveChangesAsync();
            return bannerName.ToCreateBannerResponce();
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var banner = await _context.Banners.FindAsync(id);
            if (banner == null)
                return default;
            _fileService.DeleteFile(banner.ImagePath);
            _context.Remove(banner);
            await _context.SaveChangesAsync();
            return banner.Id; 
        }

        public async Task<IEnumerable<BannerResponce>> GetAllAsync()
        {
            return await _context.Banners.Include(x => x.Post).Select(x =>
            new BannerResponce
            {
                Id = x.Id,
                ImagePath = x.ImagePath,
                PostId = x.Post.Id,
                DescriptionBanner = x.Description
                //Title = x.Post.Title,
                //Description = x.Post.Description
            }).ToListAsync();
        }

        public async Task<BannerResponce> GetbyIdAsync(int id)
        {
            var banner = await _context.Banners.FindAsync(id);
            return banner?.ToBannerResponce();
        }
    }
}
