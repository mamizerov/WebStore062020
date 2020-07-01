using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebStore062020.Infrastructure.Services;
using WebStore062020.Infrastructure.Interfaces;

namespace WebStore062020
{
    public class Startup
    {
        private readonly IConfiguration _Configuration;

        public Startup(IConfiguration Configuration)
        {
            _Configuration = Configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddScoped<IEmployeesData, InMemoryEmployeesData>();
            services.AddScoped<IBlogsData, InMemoryBlogsData>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"default",
                    pattern: "{controller=Home}/{action=Index}/{ID?}");
            });
        }
    }
}
