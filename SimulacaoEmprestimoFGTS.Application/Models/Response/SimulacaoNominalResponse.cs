using Amazon.DynamoDBv2.DataModel;
using System;

namespace SimulacaoEmprestimoFGTS.Application.Models.Response
{
    [DynamoDBTable("tbt_simulacao_nominal")]
    public class SimulacaoNominalResponse
    {
        [DynamoDBHashKey("id_simulacao")]
        public int IdSimulacao { get; private set; }

        [DynamoDBHashKey("data_simulacao")]
        public DateTime DataSimulacao { get; private set; }

        [DynamoDBHashKey("cpf")]
        public string CPF { get; private set; }

        [DynamoDBHashKey("saldo")]
        public decimal Saldo { get; private set; }

        [DynamoDBHashKey("taxa_mensal")]
        public decimal TaxaMensal { get; private set; }

        [DynamoDBHashKey("taxa_anual")]
        public decimal TaxaAnual { get; private set; }
    }
}
