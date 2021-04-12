using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VideoGames.Areas.Identity.Data;
using VideoGames.Areas.Services;
using VideoGames.Data;

namespace VideoGames
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
            services.AddDbContext<VideoGamesContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("VideoGamesContextConnection")));
            services.AddDefaultIdentity<VideoGamesUser>(options =>
            options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<VideoGamesContext>();
            
            services.AddAuthentication()
           .AddGoogle(options =>
           {
                 IConfigurationSection googleAuthNSection =
                Configuration.GetSection("Authentication:Google");

                 options.ClientId = googleAuthNSection["ClientId"];
                 options.ClientSecret = googleAuthNSection["ClientSecret"];
               
           });

            services.AddControllersWithViews();
            services.AddScoped<IUserData, UserData>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<VideoGamesUser> userManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();  
            });


            
        }
    }
}
