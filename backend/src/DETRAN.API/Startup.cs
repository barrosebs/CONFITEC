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
            services.AddDbContext<DetranContext>(
                context => context.UseSqlite(Configuration.GetConnectionString("DefaultConnection"))
            );
            services.AddControllers();
            
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
