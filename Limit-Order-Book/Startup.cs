using Limit_Order_Book.Entities;
using Microsoft.EntityFrameworkCore;

namespace Limit_Order_Book
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DatabaseContxt>(options => options.UseSqlite(connection));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
            routes.MapRoute(
                name: "default",
                template: "{controller=product}/{action=Index}/{id}");
            });
        }
    }
}
