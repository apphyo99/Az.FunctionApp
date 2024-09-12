using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices((context, service) => ConfigureServices(context, service))
    .Build();

host.Run();

void ConfigureServices(HostBuilderContext context, IServiceCollection services)
{
    
   
}