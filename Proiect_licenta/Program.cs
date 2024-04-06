using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Disertatie_backend.DatabaseContext;
using Disertatie_backend.Entities;
using System;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Disertatie_backend.Configurations;
using Microsoft.Extensions.Options;

namespace Disertatie_backend
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;
            
            try
            {
                var configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();
                IServiceCollection service = new ServiceCollection();
                service.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings"));

                var settings = services.GetRequiredService<IOptions<DatabaseSettings>>();

                var context = services.GetRequiredService<DataContext>();
                var userManager = services.GetRequiredService<UserManager<AppUser>>();
                var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
                //await context.Database.MigrateAsync();
                //await Seed.SeedUsers(userManager, roleManager);
                //await SeedMovies.SeedAllMovies(context);
                //await SeedTvShows.SeedAllTvShows(context);
                //await SeedAnime.SeedAllAnime(settings);
                //await SeedManga.SeedAllManga(settings);
                await SeedGames.SeedAllGamesIds(context);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "Error occurred during migration");
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
