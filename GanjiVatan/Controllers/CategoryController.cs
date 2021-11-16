using application.DTOs.Category;
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
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = Role.ADMIN)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateCategoryRequest request)
        {
            var categoryName = await _categoryService.CreateAsync(request);
            if (categoryName.Id == 0)
                return BadRequest();
            return Created("Category", categoryName);
        }

        [HttpGet]
     //   [Authorize(AuthenticationSchemes = "Bearer", Roles = Role.ADMIN)]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedCategoryId = await _categoryService.DeleteByIdAsync(id);
            if (deletedCategoryId == 0)
                return NotFound();
            return Ok(deletedCategoryId);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id,[FromBody] UpdateCategoryRequest request)
        {
            var category = await _categoryService.UpdateAsync(id,request);
            if (category == null)
                return NotFound();
            return Ok(category);
        }
    }
}
