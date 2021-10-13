using DETRAN.Application.Services;
using DETRAN.Application.Services.Interface;
using DETRAN.Persistence.Data.Context;
using DETRAN.Persistence.Interface;
using DETRAN.Persistence.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.Swagger;
using System;

namespace DETRAN.API
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
            services.AddCors();
            services.AddDbContext<DetranContext>(
                context => context.UseSqlite(Configuration.GetConnectionString("DefaultConnection"))
            );
            services.AddControllers();

            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { 
                        Title = "Detran",
                        Description = "CONFITEC API TESTE DETRAN ",
                        Contact = new OpenApiContact
                        {
                            Name = "Eduardo Barros",
                            Email = "barrosebs@gmail.com",
                            Url = new Uri("https://www.linkedin.com/in/barrosebs/"),
                        }
                    });
                });

            services.AddScoped<ICondutorService, CondutorService>();
            services.AddScoped<IAllPersist, AllPersist>();
            services.AddScoped<ICondutorPersist, CondutorPersist>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();


            app.UseCors(
                x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
            );
            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(
                c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API DETRAM v1");
                }
            );

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
