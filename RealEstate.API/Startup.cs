using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstate.API.Middleware;
using RealEstate.API.Repositiories;
using RealEstate.API.Services;

namespace RealEstate.API
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
            services.AddSingleton<IRealEstateRepository,RealEstateRepository>();
            services.AddSingleton<IRealEstateNoteRepository,RealEstateNoteRepository>();
            services.AddTransient<StatisticsCalculator>();

            services.AddControllers();
            services.AddSwaggerDocument(c =>
            {
                c.GenerateXmlObjects = true;
            });

            services.AddResponseCaching();
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<HeaderAdditionMiddleware>();
            //app.UseMiddleware<BearerTokenMiddleware>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseDeveloperExceptionPage();

            app.UseResponseCaching();
            app.UseMvc();
        }
    }
}
