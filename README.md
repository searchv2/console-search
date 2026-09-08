# console-search

A .NET console client for the Search API. It reads search queries from the
terminal, sends them to a running search service over HTTP, and prints the
matching documents.

## How it works

- `Program.cs` is the composition root: it registers the services in a DI
  container and resolves `App`, which runs the read-search-print loop.
- `App.cs` is injected with an `ISearchClient` (currently a `HttpSearchClient`)
  and only ever talks to that interface, so the underlying transport can change
  later - swap the one registration in `Program.cs` - without touching the loop.
- `HttpSearchClient` posts each query to `api/search` on the search service
  and deserializes the `SearchResult` response.
- `ApiConfig.SEARCH_API_BASE_URL` sets the base URL of the search service
  (defaults to `http://localhost:5071`).

## Setup

Requires the [.NET 10 SDK](https://dotnet.microsoft.com/download).

This project depends on the `SearchUtilities` NuGet package. `NuGet.config`
resolves it from a local folder at `../search-utilities/nupkg`, so check out
the `search-utilities` repo as a sibling of this one (or otherwise make the
package available) before restoring.

A search service implementing the `api/search` endpoint must be running and
reachable at the URL configured in `ApiConfig.SEARCH_API_BASE_URL`.

## Build and run

```bash
dotnet restore
dotnet build
dotnet run
```

## Usage

Once running, type search terms and press enter:

```
Console Search
enter search terms - q for quit
example query
```

- Separate multiple terms with spaces to search for all of them.
- Add `--case` anywhere in the input to make the search case-sensitive.
- Enter `q` to quit.

For each matching document the app prints its URL, index time, the number of
search terms it contains, and which of the search terms (if any) it is
missing, followed by the total number of documents matched and the time
taken.
