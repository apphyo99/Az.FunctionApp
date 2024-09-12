using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.DurableTask.Client;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using DurableTask.Core;

namespace FunctionApp;

public static class BatchStarter
{
    [Function("StartBatchProcessing")]
    public static async Task<HttpResponseData> StartBatchProcessing(
        [HttpTrigger(AuthorizationLevel.Function,  "post")] HttpRequestData req,
        [DurableClient] DurableTaskClient client)
    {
        var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var batchData = JsonSerializer.Deserialize<List<string>>(requestBody);

        var instanceId = await client.ScheduleNewOrchestrationInstanceAsync(
            nameof(BatchOrchestrator), batchData);

        // Construct the status URLs
        var statusQueryGetUri = $"{req.Url.Scheme}://{req.Url.Host}:{req.Url.Port}/runtime/webhooks/durabletask/instances/{instanceId}";
        var statusUri = new Uri(statusQueryGetUri);

        // Return the status URLs
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Location", statusUri.ToString());
        
        return response;
    }
}