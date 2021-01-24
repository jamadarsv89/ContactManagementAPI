using AutoMapper;
using ContactManagement.API.Filter;
using ContactManagement.API.Logger;
using ContactManagement.API.Mapping;
using ContactManagement.Data;
using ContactManagement.Data.Entity;
using ContactManagement.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace ContactManagement.API
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
            services.AddControllers();

            services.AddMvc(config => config.Filters.Add(typeof(CustomExceptionFilter)));

            services.AddSingleton<ILoggerManager, LoggerManager>();

            //services.AddDbContext<ContactDbContext>(options => options.UseSqlServer("MyConnectionString"));
            services.AddScoped<DbContext, ContactDbContext>();
            services.AddDbContext<ContactDbContext>(options => options.UseInMemoryDatabase(databaseName: "ContactDB"));

            services.AddScoped<IRepository<Contact>, ContactRepository>();
            services.AddScoped<IContactManagementService, ContactManagementService>();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Contact Management API",
                    Version = "1.0"
                });

                var xmlFile = Path.ChangeExtension(typeof(Startup).Assembly.Location, ".xml");
                c.IncludeXmlComments(xmlFile);
            });

            using (var provider = services.BuildServiceProvider())
            {
                provider.GetService<ContactDbContext>().Seed();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Sample");
            });
        }
    }
}
