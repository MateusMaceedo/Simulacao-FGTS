﻿using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using SimulacaoEmprestimoFGTS.Domain.interfaces;
using System.Threading.Tasks;

namespace SimulacaoEmprestimoFGTS.Repository.Data
{
    public class DynamoDbContext<T> : DynamoDBContext, IDynamoDbContext<T>where T : class
    {
        public DynamoDbContext(IAmazonDynamoDB client)
        : base(client)
        {}

        public async Task<T> GetByIdAsync(string id)
        {
            return await base.LoadAsync<T>(id);
        }

        public async Task SaveAsync(T item)
        {
            await base.SaveAsync(item);
        }

        public async Task DeleteByIdAsync(T item)
        {
            await base.DeleteAsync(item);
        }
    }
}
