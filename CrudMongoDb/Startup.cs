using CrudMongoDb.Models;
using CrudMongoDb.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace CrudMongoDb
{
    internal class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen();

            // requires using Microsoft.Extensions.Options
            services.Configure<CrudMongoDbSettings>(
                Configuration.GetSection(nameof(CrudMongoDbSettings)));

            services.AddSingleton<ICrudMongoDbSettings>(sp =>
                sp.GetRequiredService<IOptions<CrudMongoDbSettings>>().Value);

            services.AddSingleton<CrudMongoDbService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });

            app.UseRouting();
            app.UseEndpoints(configure => configure.MapControllers());
        }
    }
}