using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config) //our configuration is injected into the startup class
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) //this is reffered to as dependency injection container
                                                                   //if we want to make something available to other parts of the application we add them to this container
        {                                                           //dotnet takes care of creation and destruction of these classes

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(_config.GetConnectionString("DefaultConnection"));
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //we make a request from our browser to our controller endpoint. the request goes through a series of middleware on the way in and out
        //
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) //check if were in dev mode
            {
                app.UseDeveloperExceptionPage(); //if we encounter a problem our app uses the devExceptionPage
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection(); //redirection if we come in on a http address then we get redirected to the https endpoint

            app.UseRouting(); //

            app.UseAuthorization(); //

            app.UseEndpoints(endpoints => //middleware to actually use the endpoints
            {
                endpoints.MapControllers(); //takes a look inside our controllers to see what endpoints are available
            });
        }
    }
}