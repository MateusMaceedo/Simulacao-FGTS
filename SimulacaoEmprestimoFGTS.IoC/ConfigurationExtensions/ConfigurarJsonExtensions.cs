using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace SimulacaoEmprestimoFGTS.IoC.ConfigurationExtensions
{
    public static class ConfigurarJsonExtensions
    {
        public static void ConfigurarJson(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(
                options => {
                    var enumConverter = new JsonStringEnumConverter();
                    options.JsonSerializerOptions.Converters.Add(enumConverter);
                });
        }
    }
}
