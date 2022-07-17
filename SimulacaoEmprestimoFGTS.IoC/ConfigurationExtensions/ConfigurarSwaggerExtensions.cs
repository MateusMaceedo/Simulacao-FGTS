using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace SimulacaoEmprestimoFGTS.IoC.ConfigurationExtensions
{
    public static class ConfigurarSwaggerExtensions
    {
        public static void ConfigurarSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "SimulacaoEmprestimo" });
                swagger.DescribeAllParametersInCamelCase();
            });
        }
    }
}
