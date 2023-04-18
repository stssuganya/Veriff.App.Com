using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veriff.Utilities.DependencyResolver;

namespace Veriff.App.Com
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddCors();
            //Add Http Context Accessor
            services.AddHttpContextAccessor();
            // need to add because default json will be camel case letter property name, so that need to change
            services.AddMvc().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.ConfigureApplicationCookie(options => {
                options.Cookie.SameSite = SameSiteMode.None;
            });
            Resolver.ConfigureServices(services);
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
            app.UseCors(x => x
               .SetIsOriginAllowed(_ => true)
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials());
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Veriff}/{action=Create}/{id?}");
            });
        }
    }
}
