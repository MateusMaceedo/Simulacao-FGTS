using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimulacaoEmprestimoFGTS.Domain.Model.CONFIG;
using System;

namespace SimulacaoEmprestimoFGTS.IoC.ConfigurationExtensions
{
    public static class ConfigurarBuildExtensions
    {
        public static void ConfigurarBuild(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            services.Configure<AppConfig>(options => configuration.GetSection("AppConfig").Bind(options));
        }
    }
}
