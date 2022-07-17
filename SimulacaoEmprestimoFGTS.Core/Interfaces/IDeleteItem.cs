using System.Threading.Tasks;

namespace SimulacaoEmprestimoFGTS.Core.Interfaces
{
    public interface IDeleteItem
    {
        Task DeleteEntry(string productName, int productQuantity);
    }
}
