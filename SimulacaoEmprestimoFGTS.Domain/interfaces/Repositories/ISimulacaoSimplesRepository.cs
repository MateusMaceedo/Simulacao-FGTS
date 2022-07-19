using System;
using System.Threading;
using System.Threading.Tasks;

namespace SimulacaoEmprestimoFGTS.Domain.interfaces.Repositories
{
    public interface ISimulacaoSimplesRepository<T>
    {
        Task DeleteByIdAsync(T item, int id);
        Task<T> GetByIdAsync(string id);
        Task SaveAsync(T value, CancellationToken cancellationToken = default);
    }
}
