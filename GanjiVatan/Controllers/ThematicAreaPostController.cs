using application.DTOs.ThematicAreaPost;
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
    public class ThematicAreaPostController : BaseController
    {
        private readonly IThematicAreaPostService _thematicAreaPostService;
        public ThematicAreaPostController(IThematicAreaPostService thematicAreaPostService)
        {
            _thematicAreaPostService = thematicAreaPostService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateThematicAreaPostRequest request)
        {
            if (await _thematicAreaPostService.GetAllThematicAreaPostCount() >= 6)
                return BadRequest("Больше 6 тематических постов добавлять нельзя");
            if (request.Images.Count() != 4)
                return BadRequest("Больше 4 фотографий добавлять нельзя");
            if (request.Images == null)
                return BadRequest();
            if (request.MainImage == null)
                return BadRequest();
            var thematicAreaPost = await _thematicAreaPostService.CreateAsync(request);
            if (thematicAreaPost.Id == 0)
                return BadRequest();
            return Ok(thematicAreaPost);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var themticalAreaPosts = await _thematicAreaPostService.GetAllAsync();
            return Ok(themticalAreaPosts);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedIdThematicalPost = await _thematicAreaPostService.DeleteByIdAsync(id);
            if (deletedIdThematicalPost == 0)
                return NotFound();
            return Ok(deletedIdThematicalPost);
        }


    }
}
