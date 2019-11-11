using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bibloteca.Repositorio.Repositorios;
using Bibloteca.Servicio.Servicio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bibloteca
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
            services.AddMvc();
            //Usuario
            services.AddTransient<IUsuarioServicio, UsuarioServicio>();
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            //libro
            services.AddTransient<ILibroRepositorio, LibroRepositorio>();
            services.AddTransient<ILibroServicio, LibroServicio>();
            //prestamo
            services.AddTransient<IPrestamoRepositorio, PrestamoRepositorio>();
            services.AddTransient<IPrestamoServicio, PrestamoServicio>();
            //detalle
            services.AddTransient<IDetalleRepositorio, DetalleRepositorio>();
            services.AddTransient<IDetalleServicio,DetalleServicio>();

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(option => option.WithOrigins("http://localhost:4200/").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.UseMvc();
        }
    }
}
