using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using PetParser.Services;
using System;
using System.Net.Http;
using Microsoft.Extensions.Logging;

namespace PetParser
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
            
            // using singleton methods here so caching can be implemented effectively in future
            services.AddSingleton<IPetParse, PetParse>();
            services.AddSingleton<IPetHttpHandler, PetHttpHandler>();

            services.AddLogging(builder =>
            {
                builder.AddConfiguration(Configuration.GetSection("Logging"))
                        .AddFilter("System", LogLevel.Debug)
                        .AddConsole()
                        .AddDebug();
            });

            Uri uri = new Uri(Configuration.GetSection("URI").Value);
            HttpClient httpClient = new HttpClient()
            {
                BaseAddress = uri,
            };

            // re using HttpClient class instead of wrapping in a using statement as recommended
            services.AddSingleton<HttpClient>(httpClient);
            services.AddMvc(
                config => {
                    config.Filters.Add(typeof(ExceptionHandler));
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
