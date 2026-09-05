using System.Threading.Tasks;
using Shared.Model;

namespace ConsoleSearch
{
    // "IA" from the proxy step: every frontend talks to search only through this
    // interface, obtained from SearchClientFactory - so how a search is actually reached
    // (direct HTTP call today, a proxy with retries/caching later) never leaks into App.cs.
    public interface ISearchClient
    {
        Task<SearchResult> SearchAsync(string[] query, bool caseSensitive);
    }
}
