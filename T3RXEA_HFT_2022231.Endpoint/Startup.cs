using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T3RXEA_HFT_2022231.Logic;
using T3RXEA_HFT_2022231.Repository;

namespace T3RXEA_HFT_2022231.Endpoint
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<ShoeManamegementDBContext, ShoeManamegementDBContext>();
            services.AddTransient<IBrandLogic, BrandLogic>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IShoeLogic, ShoeLogic>();
            services.AddTransient<IShoeRepository, ShoeRepository>();
            services.AddTransient<ISportLogic, SportLogic>();
            services.AddTransient<ISportRepository, SportRepository>();

            services.AddSignalR();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x.AllowCredentials().AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:2286"));
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
