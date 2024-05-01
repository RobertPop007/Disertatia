using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Disertatie_backend.Extensions;
using Disertatie_backend.Middleware;
using Disertatie_backend.SignalR;
using Disertatie_backend.DatabaseContext;
using Disertatie_backend.Entities.Movies;
using Disertatie_backend.Interfaces;
using Disertatie_backend.Configurations;
using MongoDB.Bson;
using Microsoft.AspNetCore.Authentication.Cookies;
using Hangfire;
using Disertatie_backend.Hangfire;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Disertatie_backend
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

            var facebookLoginSettings = Configuration
                .GetSection("FacebookLoginSettings")
                .Get<FacebookLoginSettings>();

            var databaseSettings = Configuration
                .GetSection("DatabaseSettings")
                .Get<DatabaseSettings>();

            services.AddSingleton(emailConfig);
            services.AddSingleton(facebookLoginSettings);
            services.AddSingleton(databaseSettings);

            services.AddApplicationServices(Configuration);

            services.AddControllers();

            services.AddHttpClient();

            services.AddCors();

            //var connectionString = Configuration.GetConnectionString("HangfireConnection");
            //services.AddHangfire(config => config.SetDataCompatibilityLevel((CompatibilityLevel.Version_170))
            //    .UseSimpleAssemblyNameTypeSerializer()
            //    .UseDefaultTypeSerializer()
            //    .UseSqlServerStorage(connectionString));
            //services.AddHangfireServer();

            // Add Hangfire services.
            services.AddHangfire(configuration => configuration
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(Configuration.GetConnectionString("HangfireConnection")));

            // Add the processing server as IHostedService
            services.AddHangfireServer();

            services.AddIdentityServices(Configuration);

            services.AddSignalR();

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Proiect_disertatie", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.AddServer(new OpenApiServer()
                {
                    Url = "https://localhost:5001"
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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Proiect disertație"));
            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
              .AllowAnyMethod()
              .AllowAnyHeader()
              .SetIsOriginAllowed(origin => true) // allow any origin  
              .AllowCredentials()); // allow credentials  

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
