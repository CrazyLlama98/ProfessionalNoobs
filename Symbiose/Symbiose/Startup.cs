using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.AspNetCore.Identity;
using Symbiose.Data.Models.Account;
using Symbiose.Data;
using Symbiose.Extensions;
using Microsoft.Extensions.Configuration;

namespace Symbiose
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthServices()
                .AddCookieOptions()
                .AddDbServices();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IHostingEnvironment env, UserContext userContext, SymbioseContext symbioseContext)
        {
            userContext.Database.EnsureCreated();
            symbioseContext.Database.EnsureCreated();
            if (env.IsDevelopment())
            {
                var options = new WebpackDevMiddlewareOptions() { HotModuleReplacement = true };
                app.UseWebpackDevMiddleware(options);
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            await app.EnsureRolesCreatedAsync(Configuration);
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                // Setup additional routing for SPA
                routes.MapSpaFallbackRoute(
                  name: "spa-fallback",
                  defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
