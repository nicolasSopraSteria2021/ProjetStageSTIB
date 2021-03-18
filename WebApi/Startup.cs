using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProjetStageSTIB.Application.Repositories;
using ProjetStageSTIB.Application.Service;
using ProjetStageSTIB.Application.Service.Lines;
using ProjetStageSTIB.Application.Service.Stations;
using ProjetStageSTIB.Application.Service.TrackingVehicules;
using ProjetStageSTIB.Application.Service.Vehicules;
using ProjetStageSTIB.Infrastructure.SqlServer.Category;
using ProjetStageSTIB.Infrastructure.SqlServer.Lines;
using ProjetStageSTIB.Infrastructure.SqlServer.Stations;
using ProjetStageSTIB.Infrastructure.SqlServer.TrackingVehicules;
using ProjetStageSTIB.Infrastructure.SqlServer.Vehicule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        readonly string MyAllowSpeficicOrigins = "_myAllowSpeficicOrigins";
        public void ConfigureServices(IServiceCollection services)
        {
           

            services.AddControllers();
            services.AddCors(c =>
            {
                c.AddPolicy("MyAllowSpeficicOrigins", builder =>
                 {
                     builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
                 });
            });


            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<IStationService, StationService>();
            services.AddSingleton<IStationRepository, StationRepository>();
            services.AddSingleton<IVehiculeService, VehiculeService>();
            services.AddSingleton<IVehiculeRepository, VehiculeRepository>();
            services.AddSingleton<ITrackingVehiculeService, TrackingVehiculeService>();
            services.AddSingleton<ITrackingVehiculeRepository, TrackingVehiculeRepository>();
            services.AddSingleton<ILineService, LineService>();
            services.AddSingleton<ILineRepository, LineRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
       
            }

            if (env.IsProduction())
            {
                app.UseHttpsRedirection();
            }


            app.UseRouting();
            app.UseCors(options=>options.AllowAnyOrigin());
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
