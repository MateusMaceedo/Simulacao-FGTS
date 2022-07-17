using Microsoft.AspNetCore.Mvc;
using SimulacaoEmprestimoFGTS.Core.Interfaces;
using SimulacaoEmprestimoFGTS.Domain.Model.ITEM;
using System.Threading.Tasks;

namespace SimulacaoEmprestimoFGTS.Api.Controllers.Base
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AWSProductListDynamoDBController : Controller //Base
    {
        private readonly IAWSProductListDynamoDbExamples _dynamoDbExamples;
        private readonly IInsertItem _insertItem;
        private readonly IQueryItem<Item> _queryItem;
        private readonly IDeleteItem _deleteItem;

        public AWSProductListDynamoDBController(
            IAWSProductListDynamoDbExamples dynamoDbExamples, 
            IInsertItem insertItem, 
            IQueryItem<Item> queryItem, 
            IDeleteItem deleteItem)
        {
            _dynamoDbExamples = dynamoDbExamples;
            _insertItem = insertItem;
            _queryItem = queryItem;
            _deleteItem = deleteItem;
        }

        [Route("createtable")]
        public IActionResult CreateDynamoDbTable()
        {
            _dynamoDbExamples.CreateDynamoDbTable();

            return Ok();
        }

        [HttpPost]
        [Route("insertitem")]
        public IActionResult InsertItem([FromQuery] string productName, int productQuantity)
        {
            _insertItem.AddNewEntry(productName, productQuantity);

            return Ok();
        }

        [HttpGet]
        [Route("queryitems")]
        public async Task<IActionResult> GetItems([FromQuery] string productName)
        {
            var response = await _queryItem.GetItems(productName);

            return Ok(response);
        }

        [HttpDelete]
        [Route("deleteitems")]
        public IActionResult DeleteItems([FromQuery] string productName, int productQuantity)
        {
            _deleteItem.DeleteEntry(productName, productQuantity);

            return Ok();
        }
    }
}
