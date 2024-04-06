using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Disertatie_backend.Entities;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using MongoDB.Driver;
using Disertatie_backend.DTO.Identity;

namespace Disertatie_backend.DatabaseContext
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var mongoDb = mongoClient.GetDatabase("Database_disertație");

            if(mongoDb.ListCollectionNames().ToList().Contains("Users") == false) mongoDb.CreateCollection("Users");
            if(mongoDb.ListCollectionNames().ToList().Contains("Roles") == false)  mongoDb.CreateCollection("Roles");

            //if (_usersCollection.CountDocuments(_ => true) >= 0) return;

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
                try
                {
                    await roleManager.CreateAsync(role);
                }
                catch (System.Exception ex)
                {

                    throw;
                }

            }

            foreach (var user in users)
            {
                user.UserName = user.UserName.ToLower();

                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, "Member");
            }

            var admin = new AppUser
            {
                UserName = "admin"
            };

            await userManager.CreateAsync(admin, "Pa$$w0rd");
            await userManager.AddToRolesAsync(admin, new[] { "Admin"});
        }
    }
}
