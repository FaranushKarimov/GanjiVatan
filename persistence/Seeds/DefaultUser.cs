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
    public static class DefaultUser
    {
        public static async Task AddDefaultUserAsync(UserManager<User> userManager)
        {
            var admin = await userManager.FindByNameAsync("Admin");
            if (admin == null)
            {
                admin = new User()
                {
                    UserName = "Admin",
                    PhoneNumber = "Admin",
                    Email = "Admin@gmail.com"
                };
                var result = await userManager.CreateAsync(admin, "@dm!n123");
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(admin, Role.ADMIN);
            }
        }
    }
}
