using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proiect_licenta.DatabaseContext;
using Proiect_licenta.Interfaces;

namespace Proiect_licenta.Services
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
