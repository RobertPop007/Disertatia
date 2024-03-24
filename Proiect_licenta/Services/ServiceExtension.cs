using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Disertatie_backend.DatabaseContext;
using Disertatie_backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disertatie_backend.Services
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
