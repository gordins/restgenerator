using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace RestGenerator.Web
{

    /*be gordin
    so I want here in starup.cs să fac un fel de rute dinamice
    in sensu sa am aici un dictionar ceva

    da prima parte e fezabila
    a doua cu adaugatu e mai tricky smichi
    da gen prima parte cum 
    */
    internal class Startup
    {
        //dic cu rute care sa se injecteze la startup.. la startup sa fie luate din db si sa pot sa adaug intre timp
        public void ConfigureServices(IServiceCollection services)
        {
            services.InjectDependencies();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value) && !context.Request.Path.Value.StartsWith("/api/"))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });

            app.UseMvc(routes =>
            {
                GordinRoutes.ActiveRoutes.ForEach(activeRoute =>
                {
                    routes.MapRoute("default",
                        "{controller}/{action}/{id?}",
                        new { controller = "Home", action = "Index" },
                        new { controller = @"^(?!User).*$" }// exclude user controller
                    );

                });
                // si aici pun ceva o clasa statica in care tot
            });
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}
