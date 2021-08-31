using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using App.ExtendMethods;
using App.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace App
{
  public class Startup
    {
        public static string ContentRootPath { get; set; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            ContentRootPath = env.ContentRootPath;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            // services.AddTransient(typeof(ILogger<>), typeof(Logger<>)); //Serilog
            services.Configure<RazorViewEngineOptions>(options => {
                // /View/Controller/Action.cshtml
                // /MyView/Controller/Action.cshtml
                
                // {0} -> ten Action
                // {1} -> ten Controller
                // {2} -> ten Area
                options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);

                options.AreaViewLocationFormats.Add("/MyAreas/{2}/Views/{1}/{0}.cshtml");

            });

            // services.AddSingleton<ProductService>();
            // services.AddSingleton<ProductService, ProductService>();
            // services.AddSingleton(typeof(ProductService));
            services.AddSingleton(typeof(ProductService),  typeof(ProductService));
            services.AddSingleton<PlanetService>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.AddStatusCodePage(); // Tuy bien Response loi: 400 - 599

            app.UseRouting();        // EndpointRoutingMiddleware

            app.UseAuthentication(); // xac dinh danh tinh 
            app.UseAuthorization();  // xac thuc  quyen truy  cap

            app.UseEndpoints(endpoints =>
            {
                // /sayhi
                endpoints.MapGet("/sayhi", async (context) => {
                    await context.Response.WriteAsync($"Hello ASP.NET MVC {DateTime.Now}");
                });

                // endpoints.MapControllers
                // endpoints.MapControllerRoute
                // endpoints.MapDefaultControllerRoute
                // endpoints.MapAreaControllerRoute

                // [AcceptVerbs]
 
                // [Route]

                // [HttpGet]
                // [HttpPost]
                // [HttpPut]
                // [HttpDelete]
                // [HttpHead]
                // [HttpPatch]

                // Area

                endpoints.MapControllers();
 
                endpoints.MapControllerRoute(
                    name: "first",
                    pattern: "{url:regex(^((xemsanpham)|(viewproduct))$)}/{id:range(2,4)}", 
                    defaults: new {
                        controller = "First",
                        action = "ViewProduct"
                    }

                );

                endpoints.MapAreaControllerRoute(
                    name: "product",
                    pattern: "/{controller}/{action=Index}/{id?}",
                    areaName: "ProductManage"
                );
                
                // Controller khong co Area
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapRazorPages();
            });
        }
    }
}
