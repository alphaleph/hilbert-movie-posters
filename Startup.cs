using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.DependencyInjection;
using MoviePostersAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.Webpack;

namespace movie_posters
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = "Server=192.168.99.100,1433;Database=MoviePostersDb;User Id=sa;Password=Passw0rd1!";
            services.AddDbContext<MoviePostersDbContext>( options => options.UseSqlServer(connectionString) );
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, MoviePostersDbContext moviePostersDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            MoviePostersDbContextExtensions.CreateSeedData(moviePostersDbContext);

            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings[".webmanifest"] = "application/manifest+json";

            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions 
            {
                ContentTypeProvider = provider
            });
            app.UseCookiePolicy();
            app.UseMvcWithDefaultRoute();
            app.UseMvc(routes => 
            {
                routes.MapRoute(name: "catch-all",
                    template: "{*url}",
                    defaults: new { controller = "Home", action = "Index" });
            });

        }
    }
}
