using SimulacaoEmprestimoFGTS.Domain.Model.ITEM;
using System.Threading.Tasks;

namespace SimulacaoEmprestimoFGTS.Core.Interfaces
{
    public interface IUpdateItem
    {
        Task Update(string productName, int productQuantity);
    }
}
