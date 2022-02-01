using ASP.NETCoreEmptyProject.Data;
using ASP.NETCoreEmptyProject.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JavaScriptEngineSwitcher.V8;
using JavaScriptEngineSwitcher.ChakraCore;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using React.AspNet;
using ASP.NETCoreEmptyProject.Models.Interfaces;
using ASP.NETCoreEmptyProject.Service;
using ASP.NETCoreEmptyProject.Models.Service;

namespace ASP.NET_Core_Empty_Project
{
    public class Startup
    {
        

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddDbContext<PeopleDBContext>(options =>
            options.UseMySql(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
              .AddDefaultUI()
              .AddDefaultTokenProviders()
              .AddEntityFrameworkStores<PeopleDBContext>();

            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddReact();

            //services.AddJsEngineSwitcher(options => options.DefaultEngineName = V8JsEngine.EngineName)
            //    .AddV8();

            services.AddJsEngineSwitcher(options => options.DefaultEngineName = ChakraCoreJsEngine.EngineName)
                 .AddChakraCore();

            services.AddControllersWithViews();

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
                app.UseExceptionHandler("Home/Error");

                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseReact(config =>
            {
                //config.AddScript("file");
            }
            );

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            //app.UseIdentity();


            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapControllerRoute(
                    name: "doctor",
                    pattern: "FeverCheck",
                    defaults: new { Controller = "Doctor", action = "FeverCheck" });
                endpoints.MapControllerRoute(
                    name: "game",
                    pattern: "GuessingGame",
                    defaults: new { Controller = "Game", action = "GuessingGame" });
                endpoints.MapControllerRoute(
                    name: "people",
                    pattern: "People",
                    defaults: new { Controller = "People", action = "PeopleIndex" });
                endpoints.MapRazorPages();
            });
        }
    }
}