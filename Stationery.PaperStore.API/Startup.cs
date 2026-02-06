using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stationery.PaperStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Stationery.PaperStore.API.Helpers;
using Stationery.PaperStore.API.Middleware;
using Stationery.PaperStore.API.Extensions;
using Stationery.PaperStore.Infrastructure.Identity;
using StackExchange.Redis;

namespace Stationery.PaperStore.API
{
    public class Startup 
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddControllers();
            services.AddDbContext<StationeryStoreContext>(x => x.UseSqlServer(_config.GetConnectionString("StationeryStoreConnection")));
            services.AddDbContext<AppIdentityDbContext>(x => x.UseSqlServer(_config.GetConnectionString("IdentityConnection")));
            services.AddSingleton<IConnectionMultiplexer>(c => {
                var config = ConfigurationOptions.Parse(_config.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(config);
            });
            services.AddAppServices();
            services.AddIdentityServices(_config);
            services.AddSwaggerDoc();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:7256");
                });
            });
        }
    
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSwaggerDoc();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
