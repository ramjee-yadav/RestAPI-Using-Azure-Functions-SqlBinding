using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace FunctionApp_Isolated_SqlBinding
{
    public class GetOrderItem
    {
        private readonly ILogger<GetOrderItem> _logger;

        public GetOrderItem(ILogger<GetOrderItem> logger)
        {
            _logger = logger;
        }

        [Function("GetOrderItem")]
        public async Task<HttpResponseData> Run(
             [HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetOrderItem/{order_item_id}")] HttpRequestData req,
             [SqlInput("select * from Orders where order_item_id = @order_item_id", "SqlConnectionString", parameters: "@order_item_id={order_item_id}")]
              IEnumerable<Orders> ord)
        {
            Console.WriteLine(ord.FirstOrDefault());
            Console.WriteLine("row count " + ord.Count());
            _logger.LogInformation("C# HTTP trigger with SQL Input Binding function processed a request for function GetOrderItems");
            _logger.LogInformation("Product rows fetched:" + ord.Count());
            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(ord);
            return response;
        }
    }
}
