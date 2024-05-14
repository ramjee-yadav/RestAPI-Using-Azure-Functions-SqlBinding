using System;
using System.Collections.Generic;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;
using System.Net;

namespace FunctionApp_Isolated_SqlBinding
{
    public class GetOrderItemListFromView
    {
        private readonly ILogger _logger;

        public GetOrderItemListFromView(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<GetOrderItemFromView>();
        }

        [Function("GetOrderItemListFromSP")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "getOrderItemList-sp/{order_id}")] HttpRequestData req,
            [SqlInput("SelectOrderItemList_SP","SqlConnectionString",System.Data.CommandType.StoredProcedure, "@order_id={order_id}")]
            IEnumerable<Orders> result)
        {
            _logger.LogInformation("C# HTTP trigger with SQL Input Binding function processed a request for GetOrderItemListFromSP.");
            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(result);
            return response;
        }
    }
}
