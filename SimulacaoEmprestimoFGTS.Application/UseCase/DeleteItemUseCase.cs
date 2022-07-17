using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using SimulacaoEmprestimoFGTS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimulacaoEmprestimoFGTS.Application.UseCase
{
    public class DeleteItemUseCase : IDeleteItem
    {
        private static readonly string tableName = Environment.GetEnvironmentVariable("AWS_CONTENT");

        private readonly IAmazonDynamoDB _dynamoDbClient;
        public DeleteItemUseCase(IAmazonDynamoDB dynamoDbClient)
        {
            _dynamoDbClient = dynamoDbClient;
        }

        public async Task DeleteEntry(string productName, int productQuantity)
        {
            try
            {
                var queryRequest = RequestBuilder(productName, productQuantity);

                await DeleteItemAsync(queryRequest);
            }
            catch (InternalServerErrorException)
            {
                Console.WriteLine("Erro 1");
            }
            catch (ResourceNotFoundException)
            {
                Console.WriteLine("Erro 2");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.StackTrace.ToString());
            }
        }

        private DeleteItemRequest RequestBuilder(string productName, int productQuantity)
        {
            var item = new Dictionary<string, AttributeValue>
            {
                {"ProductName", new AttributeValue {S = productName}}
            };

            return new DeleteItemRequest
            {
                TableName = tableName,
                Key = item
            };
        }

        private async Task DeleteItemAsync(DeleteItemRequest request)
        {
            await _dynamoDbClient.DeleteItemAsync(request);
        }
    }
}
