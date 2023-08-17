using System;
using Microsoft.Extensions.DependencyInjection;

namespace Fetch
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped(typeof(IWebService<>), typeof(WebService<>))
                .BuildServiceProvider();

            await FetchData(serviceProvider);
        }

        private static async Task FetchData(ServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var webService = scope.ServiceProvider.GetRequiredService<IWebService<Result>>();
                var task = await webService.FetchData(Constants.API.Endpoint);

                if (task.Success)
                {
                    Console.WriteLine(task.Data.Results[0].Name.First);
                } 
                else 
                {
                    Console.WriteLine(task.Error);
                }
            }
        }
    }
}