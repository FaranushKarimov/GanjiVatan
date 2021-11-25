using application.DTOs.Description;
using application.Services;
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
    }
}
