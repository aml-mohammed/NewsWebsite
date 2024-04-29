﻿using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataSeeding
{
    public static class AppIdentityDbContextSeed
    {
        public static async Task SeedUseAsync(UserManager<AppUser> manager)
        {
            if (!manager.Users.Any())
            {
                var User = new AppUser()
                {
                    DisplayName = "Aml Mohamed",
                    Email = "amlmohamed60@gmil.com",
                    UserName = "amlmohamed60",
                    PhoneNumber = "01063915165"
                };
                await manager.CreateAsync(User, "Pa$$w0rd");
            }

        }
    }
}
    
