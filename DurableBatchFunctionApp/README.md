<b> Step 1: Setup your .NET Core Project </b>

Install the .NET SDK if you haven't already.
Create a new Durable Functions project:

```func init MHAService.AzFunctions --worker-runtime dotnet-isolated --target-framework net8.0```

<b> Step 2: Add Necessary Packages </b>
Add the Durable Functions package to your project:

```dotnet add package Microsoft.Azure.Functions.Worker.Extensions.DurableTask```


<b> Step 3: Run the app </b>

```curl -X POST http://localhost:7071/api/StartBatchProcessing -H "Content-Type: application/json" -d '["apple", "orange", "melon"]' ```