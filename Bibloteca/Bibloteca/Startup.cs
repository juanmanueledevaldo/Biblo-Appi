using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibloteca.Repositorio.Repositorios;
using Bibloteca.Servicio.Servicio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Bibloteca
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6ImxvcXVlc2VhIiwiaWF0IjoxNTE2MjM5MDIyfQ.KI2p5vksjJRiO_1R7qSkmeGZchby9gpuJHLPPkh2EUg")),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
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
         
            //Reportes
            services.AddTransient<IExcelServicio, ExcelServicio>();
            
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(option => option.WithOrigins("http://localhost:4200/").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.UseAuthentication();
            app.UseMvc();
            
        }

    }
}
