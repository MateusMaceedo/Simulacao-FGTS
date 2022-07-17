using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimulacaoEmprestimoFGTS.IoC;
using SimulacaoEmprestimoFGTS.IoC.ConfigurationExtensions;

namespace SimulacaoEmprestimoFGTS.Api
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
            ConfigurarBuildExtensions.ConfigurarBuild(services);

            ConfigurarJsonExtensions.ConfigurarJson(services);

            DependencyContainer.RegisterServices(services, Configuration);

            ConfigurarAutoMapperExtensions.ConfigurarMapper(services);

            ConfigurarSwaggerExtensions.ConfigurarSwagger(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SimulacaoEmprestimo");

            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });
        }
    }
}
