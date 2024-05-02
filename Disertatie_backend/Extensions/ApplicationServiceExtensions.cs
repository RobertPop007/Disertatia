using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Disertatie_backend.DatabaseContext;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using Disertatie_backend.Services;
using Disertatie_backend.SignalR;
using Disertatie_backend.Repositories;

namespace Disertatie_backend.Extensions
{
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
            services.AddScoped<ITvShowsRepository, TvShowsRepository>();
            services.AddScoped<IAnimeRepository, AnimeRepository>();
            services.AddScoped<IMangaRepository, MangaRepository>();
            services.AddScoped<IGamesRepository, GameRepository>();
            services.AddScoped<IBooksRepository, BooksRepository>();
            services.AddScoped<LogUserActivity>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddTransient<IRecuringHangfireJob, RecuringHangfireJob>();

            services.AddScoped(typeof(IMongoDBCollectionHelper<>), typeof(MongoDBCollectionHelper<>));
            services.AddScoped(typeof(IUserItemsRepository<>),typeof(UserItemsRepository<>));
            services.AddScoped(typeof(IReviewRepository<>),typeof(ReviewRepository<>));

            services.AddDbContext<DataContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
 