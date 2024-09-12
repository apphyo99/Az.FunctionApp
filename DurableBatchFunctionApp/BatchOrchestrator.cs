using Microsoft.Azure.Functions.Worker;
using Microsoft.DurableTask;

namespace FunctionApp;

public static class BatchOrchestrator
{
    [Function("BatchOrchestrator")]
    public static async Task<List<string>> RunBatchOrchestrator(
        [OrchestrationTrigger] TaskOrchestrationContext context)
    {
        var batchData = context.GetInput<List<string>>();

        var tasks = new List<Task<string>>();
        foreach (var data in batchData)
        {
            tasks.Add(context.CallActivityAsync<string>(nameof(BatchActivity.ProcessBatchData), data));
        }

        var results = await Task.WhenAll(tasks);
        return new List<string>(results);
    }

}