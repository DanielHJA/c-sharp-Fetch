using System;
using Microsoft.Extensions.DependencyInjection;

namespace Fetch
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IWebService, WebService>()
                .BuildServiceProvider();

            await FetchData(serviceProvider);
        }

        private static async Task FetchData(ServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var webService = scope.ServiceProvider.GetRequiredService<IWebService>();
                var result = await webService.FetchData(Constants.API.Endpoint);
                Console.WriteLine(result.Results[0].Name.Last);
            }
        }
    }
}