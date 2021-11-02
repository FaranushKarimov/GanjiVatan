using application.DTOs.Post;
using application.Services;
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostRequest request)
        {
            var post = await _postService.CreateAsync(request);
            if (post.Id == 0)
                return BadRequest();
            return Created("Post", post);
        }
    }
}
