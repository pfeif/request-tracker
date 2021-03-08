using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RequestTracker.Data;

namespace RequestTracker
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Environment = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // SQLite might not be appropriate for production code. I'm using it for this project,
            //  but if I wanted to change the Environment to Production, this is where the switch to
            //  SQL Server could happen.
            if (Environment.IsDevelopment())
            {
                // Connect to SQLite database specified in appsettings.json. Because one shouldn't
                //  comment JSON files, I'll mention that the connection string specifically enables
                //  foreign keys and leave this here:
                //  https://docs.microsoft.com/en-us/dotnet/standard/data/sqlite/connection-strings
                services.AddDbContext<RequestTrackerContext>(options
                    => options.UseSqlite(
                        Configuration.GetConnectionString("RequestTrackerContext")));
            }
            else
            {
                services.AddDbContext<RequestTrackerContext>(options
                    => options.UseSqlServer(
                        Configuration.GetConnectionString("RequestTrackerContext")));
            }

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
