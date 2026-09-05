using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Shared.Model;

namespace ConsoleSearch
{
    public class HttpSearchClient : ISearchClient
    {
        // BEDocument (nested in SearchResult) exposes public fields, not properties, and
        // SearchAPI serializes with camelCase property names.
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            IncludeFields = true,
            PropertyNameCaseInsensitive = true,
        };

        private readonly HttpClient mHttpClient;

        public HttpSearchClient(HttpClient httpClient)
        {
            mHttpClient = httpClient;
        }

        public async Task<SearchResult> SearchAsync(string[] query, bool caseSensitive)
        {
            var response = await mHttpClient.PostAsJsonAsync(
                "api/search", new SearchRequest(query, caseSensitive), JsonOptions);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<SearchResult>(JsonOptions);
            return result ?? throw new InvalidOperationException("SearchAPI returned an empty response.");
        }
    }
}
