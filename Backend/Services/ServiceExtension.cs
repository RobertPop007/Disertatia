using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Backend.DatabaseContext;
using Backend.Interfaces;

namespace Backend.Services;

public static class ServiceExtensions
{
    public static void AddCrud<TEntity, TContext>(this IServiceCollection services)
        where TEntity : class
        where TContext : DbContext
    {
        services.AddTransient<IBaseRepository<TEntity, TContext>, BaseRepository<TEntity, TContext>>();
    }
}
