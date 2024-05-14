using System;
using System.Collections.Generic;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;
using System.Net;

namespace FunctionApp_Isolated_SqlBinding
{
    public class GetOrderItemFromView
    {
        private readonly ILogger _logger;

        public GetOrderItemFromView(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<GetOrderItemFromView>();
        }

        [Function("GetOrderItemFromView")]        
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetOrderItem-View/")] HttpRequestData req,
            [SqlInput("SELECT * FROM [dbo].[OrderDetails_VW]", "SqlConnectionString")] IEnumerable<OrdersView> ordview)
        {
            _logger.LogInformation("C# HTTP trigger with SQL Input Binding function processed a request for GetOrderItemFromView.");
            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(ordview);
            return response;
        }
    }
}
