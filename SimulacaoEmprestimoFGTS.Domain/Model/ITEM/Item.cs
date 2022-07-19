using System;

namespace SimulacaoEmprestimoFGTS.Domain.Model.ITEM
{
    public class Item
    {
        public int IdSimulacao { get; set; }
        public DateTime DataSimulacao { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
    }
}
