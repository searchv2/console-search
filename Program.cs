using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleSearch
{
    class Program
    {
        static async Task Main()
        {
            var services = new ServiceCollection();

            // Composition root. The one place that decides how search is reached:
            // a plain HttpSearchClient today, a proxy (retries, caching, ...) later
            // means changing only this registration.
            services.AddSingleton(new HttpClient { BaseAddress = new Uri(ApiConfig.SEARCH_API_BASE_URL) });
            services.AddSingleton<ISearchClient, HttpSearchClient>();
            services.AddSingleton<App>();

            using var provider = services.BuildServiceProvider();
            await provider.GetRequiredService<App>().Run();
        }
    }
}
