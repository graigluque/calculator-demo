using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;

// using com.glc.demo.calculator;

namespace com.glc.demo.calculator
{
    public static class Function
    {
        [FunctionName("test")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }

        [FunctionName("negotiate")]
        public static SignalRConnectionInfo GetSingalRInfo(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [SignalRConnectionInfo(HubName = "calculator")] SignalRConnectionInfo connectionInfo,
            ILogger log)
        {
            // , ConnectionStringSetting = "AzureSignalRConnectionString"
            log.LogInformation("C# HTTP trigger function processing a 'negotiate' request.");
            log.LogInformation(req.Body.ToString() + "-" + connectionInfo.Url + "-" + connectionInfo.AccessToken);



            return connectionInfo;
        }

        [FunctionName("CalculateTrigger")]
        public static void CalculateTrigger(
            [ServiceBusTrigger("calculations", Connection = "glccalculatordemobus_SERVICEBUS")] string myQueueItem,
            [SignalR(HubName = "calculator")] IAsyncCollector<SignalRMessage> singalRMessage,
            ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            dynamic data = JsonConvert.DeserializeObject(myQueueItem);

            float firstNumber = data?.firstNumber;
            float secondNumber = data?.secondNumber;
            string operation = data?.operation;

            // Call operation method
            string result = Operation.Calculate(firstNumber, secondNumber, operation);

            log.LogInformation("Result: " + result);

            singalRMessage.AddAsync(
                item: new SignalRMessage
                {
                    Target = "newCalculation",
                    Arguments = new[] { result }
                }
            );
        }

        [FunctionName("calculate")]
        public static async Task Calculate(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [SignalRConnectionInfo(HubName = "calculator")] IAsyncCollector<SignalRMessage> singalRMessage,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processing a 'calculation' request.");
            log.LogInformation(req.Body.ToString());

            // Get Body (Post) or Url (quick test use Get) Params
            string firstNumber = req.Query["firstNumber"];
            string secondNumber = req.Query["secondNumber"];
            string operation = req.Query["operation"];
            string userId = req.Query["userId"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            firstNumber = secondNumber ?? data?.firstNumber;
            secondNumber = secondNumber ?? data?.secondNumber;
            operation = operation ?? data?.operation;
            userId = userId ?? data?.userId;

            // Call operation method
            string result = Operation.Calculate(float.Parse(firstNumber), float.Parse(secondNumber), operation);

            await singalRMessage.AddAsync(
                item: new SignalRMessage
                {
                    Target = "newCalculation",
                    Arguments = new[] { result },
                    UserId = userId
                }
            );
        }
    }
}
