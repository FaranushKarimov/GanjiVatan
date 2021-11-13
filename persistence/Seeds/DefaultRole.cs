using domain.Common;
using domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persistence.Seeds
{
    public static class DefaultRole
    {
        public static async Task AddDefaultRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(Role.ADMIN))
                await roleManager.CreateAsync(new IdentityRole(Role.ADMIN));
        }
    }
}
