using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using RealEstate.API.DTO;
using RealEstate.API.Middleware;
using RealEstate.API.Repositiories;
using RealEstate.API.Services;
using RealEstate.API.Validators;

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

            services.AddMvc()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateRealEstateDtoValidator>());

           services.AddControllers()
               .AddNewtonsoftJson(options =>
                   options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseMiddleware<BearerTokenMiddleware>();
            app.UseMiddleware<HeaderAdditionMiddleware>();

            app.UseRouting();

            app.UseResponseCaching();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseOpenApi();
            app.UseSwaggerUi3();

            //app.UseDeveloperExceptionPage();

            
        }
    }
}
