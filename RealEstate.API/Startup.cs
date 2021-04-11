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
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstate.API.Infrastructure;
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
            services.AddTransient<IRealEstateRepository,RealEstateRepository>();
            services.AddTransient<IRealEstateNoteRepository,RealEstateNoteRepository>();
            services.AddTransient<StatisticsCalculator>();

            services.AddControllers();
            services.AddSwaggerDocument(c =>
            {
                c.GenerateXmlObjects = true;
            });

            services.AddResponseCaching();
            //services.AddMvc(options => options.EnableEndpointRouting = false);

            
            services.AddDbContext<RealEstateDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("RealEstateContext")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

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

            //app.UseDeveloperExceptionPage();

            app.UseResponseCaching();
            //app.UseMvc();
        }
    }
}
