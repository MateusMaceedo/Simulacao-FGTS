﻿using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using SimulacaoEmprestimoFGTS.Core.Interfaces;
using SimulacaoEmprestimoFGTS.Domain.Model.ITEM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimulacaoEmprestimoFGTS.Application.UseCase
{
    public class QueryItemUseCase : IQueryItem<DynamoDbTableItems>
    {
        private readonly IAmazonDynamoDB _dynamoDbClient;
        private static readonly string tableName = Environment.GetEnvironmentVariable("AWS_CONTENT");

        public QueryItemUseCase(IAmazonDynamoDB dynamoDbClient)
        {
            _dynamoDbClient = dynamoDbClient;
        }

        public async Task IQueryItem<DynamoDbTableItems>.GetItems(string productName)
        {
            var queryRequest = RequestBuilder(productName);

            var result = await ScanAsync(queryRequest);

            return new DynamoDbTableItems
            {
                Items = result.Items.Select(Map).ToList()
            };
        }

        private Item Map(Dictionary<string, AttributeValue> result)
        {
            return new Item
            {
                ProductName = result["ProductName"].S,
                ProductQuantity = Convert.ToInt32(result["ProductQuantity"].N)
            };
        }

        private async Task<ScanResponse> ScanAsync(ScanRequest request)
        {
            var response = await _dynamoDbClient.ScanAsync(request);

            return response;
        }

        private ScanRequest RequestBuilder(string? productName)
        {
            if (productName.Length <= 0)
            {
                return new ScanRequest
                {
                    TableName = tableName
                };
            }

            return new ScanRequest
            {
                TableName = tableName,
                ExpressionAttributeValues = new Dictionary<string, AttributeValue> {
                    {
                        ":v_ProductName",  new AttributeValue { S = productName }
                    }

                },
                FilterExpression = "ProductName = :v_ProductName",
                ProjectionExpression = "ProductName, ProductQuantity"
            };
        }
    }
}
