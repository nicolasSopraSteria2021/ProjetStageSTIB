using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetStageSTIB.Application.Repositories;
using ProjetStageSTIB.Application.Service.Lines;
using ProjetStageSTIB.Application.Service.TrackingVehicules;
using ProjetStageSTIB.Infrastructure.SqlServer.Lines;
using ProjetStageSTIB.Infrastructure.SqlServer.TrackingVehicules;

namespace ProjetStageSTIB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
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
