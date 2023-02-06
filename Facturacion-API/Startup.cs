using AutoMapper;
using Facturacion_API.Infraestructura;
using Facturacion_API.Infraestructura.Servicios.Contractos;
using Facturacion_API.Infraestructura.Servicios.Repositorios;
using Facturacion_API.Mapper;
using Facturacion_API.Servicios.Contratos;
using Facturacion_API.Servicios.Servicios;
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


        private readonly String _MyCors = "MyCors";
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

            services.AddDbContext<ContextDB>(options => options.UseSqlServer(Configuration["ConnectionStrings:ConnectionStringNombre"]));

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
            services.AddScoped<IProductoServicios, ProductoServicios>();
            services.AddScoped<ITerceroRepositorio, TerceroRepositorio>();
            services.AddScoped<IClienteServicios, ClienteServicios>();
            services.AddScoped<IFacturaDetalleRepositorio, DetalleFacturaRepositorio>();
            services.AddScoped<IFacturaRepositorio, FacturaRepositorio>();
            services.AddScoped<IFacturaServicios, FacturaServicios>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Facturacion_API", Version = "v1" });
            });


            // Optional
            services.AddCors(options =>


            {
                options.AddPolicy(name: _MyCors, Builder =>
                {
                    Builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                    .AllowAnyHeader().AllowAnyMethod();
                });

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

            //optional

            app.UseCors(_MyCors);



            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
