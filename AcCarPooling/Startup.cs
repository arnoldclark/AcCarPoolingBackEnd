﻿using AcCarPooling.Database;
using AcCarPooling.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nexmo.Api;
using Swashbuckle.AspNetCore.Swagger;

namespace AcCarPooling
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
            //services.AddCors(options => options.AddPolicy("AllowFireBaseApp",
            //    builder =>
            //    {
            //        //builder.WithOrigins("http://localhost", "http://localhost:5500", "https://ac-carpool.firebaseapp.com");
            //        builder.AllowAnyMethod();
            //        builder.AllowAnyOrigin();
            //    }));

            services.AddCors();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(x =>
                {
                    x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });


            var client = new Client(creds: new Nexmo.Api.Request.Credentials
            {
                ApiKey = Configuration["NEXMO-API-KEY"],
                ApiSecret = Configuration["NEXMO-API-SECRET"]
            });

            services.AddSingleton(client);


            //var connectionString = "Server=tcp:car-pool-db.database.windows.net,1433;Initial Catalog=CarPool;Persist Security Info=False;User ID=arnold;Password=So6LK2Tn2wGJTeM3;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            var connectionString = Configuration.GetConnectionString("car-pool-db");
            services.AddDbContext<CarPoolContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IJourneyService, JourneyService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
                {
                    //builder.WithOrigins("http://localhost", "http://localhost:5500", "https://ac-carpool.firebaseapp.com");
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();
                });

            app.UseMvc();
        }
    }
}
