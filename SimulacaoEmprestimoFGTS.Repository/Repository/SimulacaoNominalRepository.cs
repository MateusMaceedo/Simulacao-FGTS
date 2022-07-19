using SimulacaoEmprestimoFGTS.Application.Models.Response;
using SimulacaoEmprestimoFGTS.Domain.interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SimulacaoEmprestimoFGTS.Repository.Repository
{
    public class SimulacaoNominalRepository : ISimulacaoNominalRepository<SimulacaoNominalResponse>
    {
        public Task DeleteByIdAsync(SimulacaoNominalResponse item, int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<SimulacaoNominalResponse> GetByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveAsync(SimulacaoNominalResponse value, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}
