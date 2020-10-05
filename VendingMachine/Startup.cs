using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using VendingMachine.Data;
using VendingMachine.Services;

namespace VendingMachine
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient(); 
            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseNpgsql(Configuration["Data:DefaultConnection:ConnectionString"]), ServiceLifetime.Transient);
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
            services.AddMvc();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });
            services.AddHttpContextAccessor();
            services.AddTransient<ICoinService, CoinService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "spa-route",
                    template: "{controller}/{*anything=Index}",
                    defaults: new { action = "Index" });
                
                routes.MapRoute(
                   name: "app-fallback",
                   template: "{*anything}/",
                   defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}