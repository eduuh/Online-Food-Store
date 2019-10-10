using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PieShop.Models;

namespace PieShop
{
    public class Startup
    {
        // Dependecies are injected here.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<IPieRepository, MockPieRepository>();
        }

        //we register our Middleware components chained after one another. pipeline is created
        // depencecies are injected instead of creating class instances. we use constructor 
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //middleware pipeline 
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            
        
        }
    }
}
