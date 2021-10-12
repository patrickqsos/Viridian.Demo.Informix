using System;
using System.IO;
using IBM.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Viridian.Demo.Informix.DataAccess;
using Viridian.Demo.Informix.Dtos;
using Viridian.Demo.Informix.Repositories;
using Viridian.Demo.Informix.Repositories.Interfaces;

namespace Viridian.Demo.Informix
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
            var config = new ConfigDto();
            Configuration.Bind(config);
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Viridian.Demo.Informix",
                    Version = "v1"
                });
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Viridian.Demo.Informix.xml"));
            });
            
            services.AddDbContext<DemoContext>(options =>
            {
                var cs = $"DATABASE={config.Database.Db};SERVER={config.Database.Host}:{config.Database.Port};UID={config.Database.User};PWD={config.Database.Password};Authentication=SERVER;";
                options.UseDb2(cs, builder => builder.SetServerInfo(IBMDBServerType.IDS, IBMDBServerVersion.IDS_12_10_2000));
            });
            
            services.AddScoped<IUsersRepository, UsersRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Viridian.Demo.Informix v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}