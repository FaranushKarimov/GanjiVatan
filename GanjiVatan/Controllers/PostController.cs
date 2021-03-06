using application.DTOs.Post;
using application.Services;
using domain.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GanjiVatan.Controllers
{
    
    public class PostController : BaseController
    {
        private readonly IPostSerivce _postService;

        public PostController(IPostSerivce postService)
        {
            _postService = postService;
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = Role.ADMIN)]
        [HttpPost]
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = Role.ADMIN)] 
        public async Task<IActionResult> Create([FromForm] CreatePostRequest request)
        {
            //if(await _postService.GetAllPostsCount() >= 6)
            //{
            //    return BadRequest("Больше 6 тематических постов добавлять нельзя");
            //}
            //if (request.AdditionalImages.Count() > 4)
            //{
            //    return BadRequest("Too many images (more than 4)");
            //}
            if (request.Image == null)
                return BadRequest();
            var post = await _postService.CreateAsync(request);
            if (post.Id == 0)
                return BadRequest();
            return Created("Post", post);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedPostId = await _postService.DeleteByIdAsync(id);
            if (deletedPostId == 0)
                return NotFound();
            return Ok(deletedPostId);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _postService.GetAllAsync();
            return Ok(posts);
        }

        //[HttpPut("{id:int}")]
        [HttpPut]
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = Role.ADMIN)]
        public async Task<IActionResult> Update([FromForm] UpdatePostRequest request)
        {
            var post = await _postService.UpdateAsync(request);
            if (post == null)
                return NotFound();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
            return Ok(post);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _postService.GetByIdAsync(id);
            if (post == null)
                return NotFound();
            return Ok(post);
        }
    }
}
