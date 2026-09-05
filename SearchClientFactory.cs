using System;
using System.Net.Http;

namespace ConsoleSearch
{
    // "FactoryA" from the proxy step: the one place that decides which ISearchClient
    // implementation App.cs gets. Today that's always a plain HttpSearchClient; swapping in
    // a future ProxySearchClient (retries, caching, ...) means changing only this file.
    public static class SearchClientFactory
    {
        public static ISearchClient Create()
        {
            var httpClient = new HttpClient { BaseAddress = new Uri(ApiConfig.SEARCH_API_BASE_URL) };
            return new HttpSearchClient(httpClient);
        }
    }
}
