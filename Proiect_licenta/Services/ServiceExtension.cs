using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proiect_licenta.DatabaseContext;
using Proiect_licenta.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
