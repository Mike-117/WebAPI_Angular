using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer; // needed to make UseSQLServer to work
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using WebAPI.Models;

namespace WebAPI
{
    public class Startup // consists of mainly 2 functions, ConfigureServices and Configure
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // this service makes the program into a web app, without it it would be a plain console app
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            // using dependency injection for DbContext class, add a DbContext service to the ConfigurationServices method, through which SQL Server is set as a DbProvider with a connection string
            services.AddDbContext<PaymentDetailContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("DevConnection"))); // passes DevConnection from appsettings.json 

            services.AddControllers().AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    options.JsonSerializerOptions.DictionaryKeyPolicy = null;
                });


            // allows CORS functionality so that the program can receive data which is hosted from a different port number or domain 
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // sets the exception page based on the runtime environment
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // allows the API to accept requests from the Angular project
            app.UseCors(options =>
            options
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
