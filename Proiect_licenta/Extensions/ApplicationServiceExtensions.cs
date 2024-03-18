using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Proiect_licenta.DatabaseContext;
using Proiect_licenta.Helpers;
using Proiect_licenta.Interfaces;
using Proiect_licenta.Services;
using Proiect_licenta.SignalR;

namespace Proiect_licenta.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton<PresenceTracker>();
        services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
        services.AddScoped<IPhotoService, PhotoService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IAddFriendsRepository, AddFriendsRepository>();
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<IMoviesRepository, MoviesRepository>();
        services.AddScoped<LogUserActivity>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

        services.AddDbContext<DataContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

        return services;
    }
}
