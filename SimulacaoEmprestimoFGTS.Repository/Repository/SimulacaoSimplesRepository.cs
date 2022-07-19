using Amazon.DynamoDBv2.DataModel;
using SimulacaoEmprestimoFGTS.Application.Models.Request;
using SimulacaoEmprestimoFGTS.Application.Models.Response;
using SimulacaoEmprestimoFGTS.Domain.interfaces;
using SimulacaoEmprestimoFGTS.Domain.interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SimulacaoEmprestimoFGTS.Repository.Repository
{
    public class SimulacaoSimplesRepository : ISimulacaoSimplesRepository<SimulacaoSimplesResponse>
    {
        private readonly IDynamoDBContext _dynamoDBContext;

        public SimulacaoSimplesRepository(IDynamoDBContext dynamoDBContext)
        {
            _dynamoDBContext = dynamoDBContext;
        }

        public async Task DeleteByIdAsync(SimulacaoSimplesResponse item, int id)
        {
            await _dynamoDBContext.DeleteAsync<SimulacaoSimplesResponse>(item, id);
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public async Task<SimulacaoSimplesResponse> GetByIdAsync(string id)
        {
            var request = await _dynamoDBContext.LoadAsync<SimulacaoSimplesResponse>(id);
            return request;
        }

        public async Task SaveAsync(SimulacaoSimplesResponse value, CancellationToken cancellationToken = default)
        {
            await _dynamoDBContext.SaveAsync(value, cancellationToken);
        }
    }
}
