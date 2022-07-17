using System.Threading.Tasks;

namespace SimulacaoEmprestimoFGTS.Core.Interfaces
{
    public interface IInsertItem
    {
        Task AddNewEntry(string productName, int productQuantity);
    }
}
