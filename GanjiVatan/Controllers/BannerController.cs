using application.DTOs.Banner;
using application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GanjiVatan.Controllers
{
    public class BannerController : BaseController
    {
        private readonly IBannerService _bannerService;
        public BannerController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateBannerRequest request)
        {
            if (request.Image == null)
                return BadRequest();
            var banner = await _bannerService.CreateAsync(request);
            if (banner.Id == 0)
                return BadRequest();
            return Ok(banner);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var banners = await _bannerService.GetAllAsync();
            return Ok(banners);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var banner = await _bannerService.GetbyIdAsync(id);
            if (banner == null)
                return NotFound();
            return Ok(banner);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedbannerId = await _bannerService.DeleteByIdAsync(id);
            if (deletedbannerId == 0)
                return NotFound();
            return Ok(deletedbannerId);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id,[FromForm]UpdateBannerRequest request)
        {
            var banner = await _bannerService.UpdateAsync(id, request);
            if (banner == null)
                return NotFound();
            return Ok(banner);
        }
    }
}
