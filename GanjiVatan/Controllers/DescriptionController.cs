using application.DTOs.Description;
using application.Services;
using domain.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GanjiVatan.Controllers
{
    public class DescriptionController : BaseController
    {
        private readonly IDescriptionService _descriptionService;
        public DescriptionController(IDescriptionService descriptionService)
        {
            _descriptionService = descriptionService;
        }


        [Authorize(AuthenticationSchemes = "Bearer", Roles = Role.ADMIN)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDescriptionRequest request)
        {
            var description = await _descriptionService.CreateAsync(request);
            if (description.Id == 0)
                return BadRequest();
            return Created("Description", description);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var descriptions = await _descriptionService.GetAllAsync();
            return Ok(descriptions);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var description = await _descriptionService.GetById(id);
            if (description == null)
                return NotFound();
            return Ok(description);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedDescriptionId = await _descriptionService.DeleteByIdAsync(id);
            if (deletedDescriptionId == 0)
                return NotFound();
            return Ok(deletedDescriptionId);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id,[FromBody]UpdateDescriptionRequest request)
        {
            var description = await _descriptionService.UpdateAsync(id, request);
            if (description == null)
                return NotFound();
            return Ok(description);
        }
    }
}
