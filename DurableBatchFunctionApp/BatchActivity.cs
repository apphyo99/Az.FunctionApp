using Microsoft.Azure.Functions.Worker;
using System.Threading.Tasks;

namespace FunctionApp;
public static class BatchActivity
{
    [Function("ProcessBatchData")]
    public static  Task<string> ProcessBatchData([ActivityTrigger] string data)
    {
        Task.Delay(1000);

        return  Task.FromResult($"Processed: {data}");
    }
}