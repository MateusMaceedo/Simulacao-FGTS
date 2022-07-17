using SimulacaoEmprestimoFGTS.Domain.Model.ITEM;
using System.Threading.Tasks;

namespace SimulacaoEmprestimoFGTS.Core.Interfaces
{
    public interface IQueryItem<T>
    {
        Task GetItems(string productName);
    }
}
