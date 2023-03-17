using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAppMVCPractice.Domain;
using WebAppMVCPractice.Repository;

namespace WebAppMVCPractice
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
            services.AddScoped<ITenantRepository, TenantRepository>();

            services.AddControllersWithViews();

            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB; Database=ShoppingRoom; Persist Security Info=false; Trusted_Connection=True; MultipleActiveResultSets=true"
            ));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=TenantList}/{id?}");
            });
        }
    }
}
