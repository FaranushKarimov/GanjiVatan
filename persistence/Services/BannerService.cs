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
            var banner = _context.Banners.FirstOrDefault(x => x.PostId == request.PostId);
            if(banner != null)
            {
                banner.ImagePath = await _fileService.AddFileAsync(request.Image, nameof(domain.Entities.Banner));
                banner.PostId = request.PostId;
                banner.DescriptionEN = request.DescriptionBannerEN;
                banner.DescriptionTJ = request.DescriptionBannerTJ;
                await _context.SaveChangesAsync();
                return banner.ToCreateBannerResponce();
            }
            banner = request.ToBanner();
            var imagePath = await _fileService.AddFileAsync(request.Image, nameof(domain.Entities.Banner));
            banner.ImagePath = imagePath;
            await _context.Banners.AddAsync(banner);
            await _context.SaveChangesAsync();
            return banner.ToCreateBannerResponce();
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
                DescriptionENBanner = x.DescriptionEN,
                DescriptionTJBanner = x.DescriptionTJ
                //Title = x.Post.Title,
                //Description = x.Post.Description
            }).ToListAsync();
        }

        public async Task<BannerResponce> GetbyIdAsync(int id)
        {
            var banner = await _context.Banners.FindAsync(id);
            return banner?.ToBannerResponce();
        }

        public async Task<UpdateBannerResponce> UpdateAsync(int id, UpdateBannerRequest request)
        {
            var banner = await _context.Banners.FindAsync(id);
            request.ToBanner(ref banner);
            if (request.Image != null)
            {
                _fileService.DeleteFile(banner.ImagePath);
                var imagePath = await _fileService.AddFileAsync(request.Image, nameof(domain.Entities.Banner));
                banner.ImagePath = imagePath;
            }
            //if (banner == null)
            //    return null;
            //request.ToBanner(ref banner);
            _context.Banners.Update(banner);
            await _context.SaveChangesAsync();
            return banner.ToUpdateBannerResponce();
        }
    }
}
