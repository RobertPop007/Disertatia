using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Proiect_licenta.Extensions;
using Proiect_licenta.Middleware;
using Proiect_licenta.SignalR;
using Proiect_licenta.Services;
using Proiect_licenta.DatabaseContext;
using Proiect_licenta.Entities.Movies;
using System.Collections.Generic;
using Proiect_licenta.Entities;
using Hangfire;
using Proiect_licenta.Hangfire;
using Proiect_licenta.Interfaces;

namespace Proiect_licenta
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var emailConfig = Configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);

            services.AddApplicationServices(Configuration);

            services.AddControllers();

            services.AddCors();

            services.AddCrud<MovieItem, DataContext>();


            var connectionString = Configuration.GetConnectionString("HangfireConnection");
            services.AddHangfire(config => config.SetDataCompatibilityLevel((CompatibilityLevel.Version_170))
                .UseSimpleAssemblyNameTypeSerializer()
                .UseDefaultTypeSerializer()
                .UseSqlServerStorage(connectionString));
            services.AddHangfireServer();

            services.AddIdentityServices(Configuration);

            services.AddSignalR();

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Proiect_licenta", Version = "v1" });

                c.AddServer(new OpenApiServer()
                {
                    Url = "https://localhost:5001/"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IRecuringHangfireJob recurringRecomandationEmail)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Proiect_licenta v1"));
            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
              .AllowAnyMethod()
              .AllowAnyHeader()
              .SetIsOriginAllowed(origin => true) // allow any origin  
              .AllowCredentials()); // allow credentials  

            

            app.UseCors(x => x.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials() // allow credentials
                    .WithOrigins("https://localhost:4200")); // allow any origin
                                                             //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins separated with comma

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHangfireDashboard("/hangfire", new DashboardOptions()
            {
                Authorization = new[] { new CustomAuthorizeFilter() }
            });

            RecurringJob.AddOrUpdate("Recommandation emails", () => recurringRecomandationEmail.SendRecomandationsEmails(), Cron.Daily(10));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<PresenceHub>("hubs/presence");
                endpoints.MapHub<MessageHub>("hubs/message");
            });
        }
    }
}
