using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCadastroPessoa.Repositories;
using ApiCadastroPessoa.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ApiCadastroPessoa
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
            services.AddSingleton<IPessoaRepository, PessoaRepository>();
            services.AddSingleton<IPessoaService, PessoaService>();

            // CORS Policy
            services.AddCors(options => {
                options.AddPolicy("AllowCorsOrigins",
                builder =>
                {
                    builder.AllowAnyHeader()
                        .AllowAnyOrigin()
                        .WithMethods("GET", "POST", "DELETE", "PUT");
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // CORS Policy
            app.UseCors("AllowCorsOrigins");

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
