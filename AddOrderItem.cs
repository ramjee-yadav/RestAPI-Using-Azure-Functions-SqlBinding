using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace FunctionApp_Isolated_SqlBinding
{
    public class addOrderItem
    {
        private readonly ILogger<addOrderItem> _logger;

        public addOrderItem(ILogger<addOrderItem> logger)
        {
            _logger = logger;//loggerFactory.CreateLogger<GetEmployees>();
        }
        
        [Function("AddOrderItem")]
        [SqlOutput("[dbo].[Orders]", "SqlConnectionString")]
        public async Task<Orders> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "AddOrderItem")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger with SQL Output Binding function processed the request for AddOrderItem.");

            Orders ord = await req.ReadFromJsonAsync<Orders>();
            _logger.LogInformation("Order item added/updated to DB.");
            return ord;
        }
    }
}
