using CampingPlatformServer.Extensions;
using CampingPlatformServer.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using CampingPlatformServer.Model.Repository;
using CampingPlatformServer.Model.DataManager;

namespace CampingPlatformServer
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
            services.ConfigureCors();
            services.ConfigureIISIntegration();
            services.AddDbContext<CampingPlatformContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:CampingPlatformDB"]));

            services.AddScoped<IDataRepository<Guest>, GuestManager>();
            services.AddScoped<IDataRepository<GuestRequest>, GuestRequestManager>();
            services.AddScoped<IDataRepository<Model.Host>, HostManager>();
            services.AddScoped<IDataRepository<Location>, LocationManager>();
            services.AddScoped<IDataRepository<LocationDate>, LocationDateManager>();
            services.AddScoped<IDataRepository<LocationImage>, LocationImageManager>();
            services.AddScoped<IDataRepository<Admin>, AdminManager>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
