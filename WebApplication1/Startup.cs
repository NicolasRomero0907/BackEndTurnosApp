using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

/* ACA HAY QUE FIJARSE LO DE CORS EN CONFIGURE, ESO ME HABILITA A QUE MI CLIENTE ME MANDE PETICIONES DESDE ESE ORIGEN
   CON CUALQUIER TIPO DE METODO Y CUALQUIER CABECERA 
   TAMBIEN FIJARSE EN CONFIGURE SERVICES, AHI AGREGUE EL SINGLETON PARA QUE ME PERMITA INYECTAR LA CONEXION A LA BASE DE DATOS
   CON DAPPER, ES DECIR, LE PERMITO PASAR MEDIANTE INYECCION DE DEPENDENCIA LA CONFIGURACION */

namespace WebApplication1
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
            //CON ESTO PASO LA CONFIGURACION A LA BD, ESTO ES LO QUE EXPLICO AL INICIO
            services.AddSingleton<IConfiguration>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ME PERMITE USAR LOS CORS PARA PODER HACER PETICIONES DESDE MI CLIENTE
            app.UseCors(options => options.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
