using application.DTOs;
using application.DTOs.Users;
using application.Services;
using domain.Common;
using domain.Entities;
using Microsoft.AspNetCore.Identity;
using persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persistence.Services
{
    public class UserService:IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<SignInResponce> SignInAsync(SignInRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Login);
            if (user == null)
                return null;
            var correctPassword = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!correctPassword)
                return null;
            var userRole = await _userManager.GetRolesAsync(user);
            var generateTokenModel = new GenerateTokenModel
            {
                UserId = user.Id,
                Role = userRole.SingleOrDefault()
            };
            var token = JwtTokenGenerator.GenerateTokenAsync(generateTokenModel);
            return new SignInResponce
            {
                Token = token ?? throw new NullReferenceException(),
                Role = userRole.SingleOrDefault() == Role.ADMIN ? "Admin" : null
            };
        }
    }
}
