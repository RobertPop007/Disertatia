using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Disertatie_backend.Interfaces;
using Disertatie_backend.Repositories;

namespace Disertatie_backend.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCrud<TEntity, TContext>(this IServiceCollection services)
            where TEntity : class
            where TContext : DbContext
        {
            services.AddTransient<IBaseRepository<TEntity, TContext>, BaseRepository<TEntity, TContext>>();
        }
    }
}
