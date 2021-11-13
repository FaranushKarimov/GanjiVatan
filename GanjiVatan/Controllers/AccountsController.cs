using application.DTOs.Users;
using application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GanjiVatan.Controllers
{
  
    public class AccountsController : BaseController
    {
        private readonly IUserService _signInService;

        public AccountsController(IUserService signInService)
        {
            _signInService = signInService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SignIn(SignInRequest request)
        {
            var token = await _signInService.SignInAsync(request);
            if (token == null)
            {
                var error = StatusCodes.Status404NotFound.ToString();
                return BadRequest("Error! Invalid Credentials! ");
            }
            return Ok(token);
        }
    }
}
