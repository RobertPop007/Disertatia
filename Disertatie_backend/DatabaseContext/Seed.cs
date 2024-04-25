﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using MongoDB.Driver;
using Microsoft.EntityFrameworkCore;
using Disertatie_backend.Entities.User;

namespace Disertatie_backend.DatabaseContext
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (await userManager.Users.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("DatabaseContext/UserSeedData.json");

            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);

            if (users == null) return;

            var roles = new List<AppRole>
            {
                new AppRole { Name = "Member"},
                new AppRole { Name = "Admin"},
                new AppRole { Name = "Moderator"}
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            foreach (var user in users)
            {
                user.UserName = user.UserName.ToLower();
                user.Id = new System.Guid();
                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, "Member");
            }

            var admin = new AppUser
            {
                UserName = "testAdminPentruAzure"
            };

            await userManager.CreateAsync(admin, "Pa$$w0rd");
            await userManager.AddToRolesAsync(admin, new[] { "Admin" });
        }
    }
}
