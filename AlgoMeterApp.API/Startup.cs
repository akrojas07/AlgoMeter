using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlgoMeterApp.Domain.Services;
using AlgoMeterApp.Domain.Services.Interfaces;
using AlgoMeterApp.Infrastructure.Persistence.Repositories;
using AlgoMeterApp.Infrastructure.Persistence.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using MongoDB.Driver;
namespace AlgoMeterApp.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();

            var connectionString = Configuration.GetSection("ConnectionStrings:AlgoMeterDb").Value;
            var dbName = Configuration.GetSection("DatabaseName:AlgoMeter").Value;
            
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(dbName);

            services.AddSingleton<IMongoDatabase>(database);
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IQuestionsRepository, QuestionsRepository>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IQuestionsService, QuestionsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
