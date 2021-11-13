using application.DTOs;
using domain.Common;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace persistence.Extensions
{
    public class JwtTokenGenerator
    {
        public static string GenerateTokenAsync(GenerateTokenModel model)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier,model.UserId),
                new(ClaimTypes.Role,model.Role)
            };
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.KEY));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                JwtSettings.ISSUER,
                JwtSettings.AUDIENCE,
                claims,
                expires: DateTime.UtcNow.AddMinutes(JwtSettings.DURATION),
                signingCredentials: signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
