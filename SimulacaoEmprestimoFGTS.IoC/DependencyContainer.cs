using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimulacaoEmprestimoFGTS.Application.Interfaces;
using SimulacaoEmprestimoFGTS.Application.Models.Response;
using SimulacaoEmprestimoFGTS.Application.UseCase;
using SimulacaoEmprestimoFGTS.Core.Interfaces;
using SimulacaoEmprestimoFGTS.Core.Services;
using SimulacaoEmprestimoFGTS.Domain.interfaces.Repositories;
using SimulacaoEmprestimoFGTS.Repository.Repository;
using System;
using static SimulacaoEmprestimoFGTS.Application.Interfaces.IUseCaseAsync;

namespace SimulacaoEmprestimoFGTS.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(
            IServiceCollection services, 
            IConfiguration Configuration)
        {
            #region [Serviços]
            services.AddScoped<IFGTSService, FGTSService>();
            services.AddScoped<IIOFService, IOFService>();
            services.AddScoped<IConversorTaxaService, ConversorTaxaService>();
            services.AddScoped<ISACService, SACService>();
            services.AddSingleton<ICalculosService, CalculosService>();
            services.AddScoped<IPriceService, PriceService>();
            services.AddTransient<IDynamoDBContext, DynamoDBContext>();
            #endregion

            #region [DynamoDB]
            services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
            Environment.SetEnvironmentVariable("AWS_ACCESS_KEY_ID", Configuration["AWS:AccessKey"]);
            Environment.SetEnvironmentVariable("AWS_SECRET_ACCESS_KEY", Configuration["AWS:SecretKey"]);
            Environment.SetEnvironmentVariable("AWS_REGION", Configuration["AWS:Region"]);
            Environment.SetEnvironmentVariable("AWS_CONTENT", Configuration["VAR:TableName"]);
            services.AddAWSService<IAmazonDynamoDB>();
            #endregion

            #region [Casos de Uso]
            //services.AddSingleton<IHistoricoSimulacaoNominalUseCase, HistoricoSimulacaoNominalUseCase>();
            //services.AddSingleton<IInsertItem, InsertItemUseCase>();
            //services.AddSingleton<IQueryItem<DynamoDbTableItems>, QueryItemUseCase>();
            //services.AddSingleton<IDeleteItem, DeleteItemUseCase>();
            //services.AddSingleton<IUpdateItem, UpdateItemUseCase>();
            #endregion

            #region [Repository]
            services.AddScoped<ISimulacaoSimplesRepository<SimulacaoSimplesResponse>, SimulacaoSimplesRepository>();
            services.AddScoped<ISimulacaoNominalRepository<SimulacaoNominalResponse>, SimulacaoNominalRepository>();
            #endregion
        }
    }
}
