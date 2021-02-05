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
using ProjetStageSTIB.Application.Service.Stations;
using ProjetStageSTIB.Infrastructure.SqlServer.Category;
using ProjetStageSTIB.Infrastructure.SqlServer.Stations;
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
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddCors(
                options =>options.AddPolicy("MyPolicy", builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
                )
                );

          
            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<IStationService, StationService>();
            services.AddSingleton<IStationRepository, StationRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
       
            }

            app.UseHttpsRedirection();

            app.UseCors("MyPolicy");

            app.UseRouting();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
