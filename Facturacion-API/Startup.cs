using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion_API
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

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularLocal", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().Build());
            });

            //services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:ConnectionStringNombre"]));

            //var mapperConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new MapperProfile());
            //});

            //IMapper mapper = mapperConfig.CreateMapper();
            //services.AddSingleton(mapper);

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
            //services.AddScoped<IProductoServicios, ProductoServicios>();
            //services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            //services.AddScoped<IClienteServicios, ClienteServicios>();
            //services.AddScoped<IFacturaDetalleRepositorio, DetalleFacturaRepositorio>();
            //services.AddScoped<IFacturaRepositorio, FacturaRepositorio>();
            //services.AddScoped<IFacturaServicios, FacturaServicios>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Facturacion_API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Facturacion_API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
