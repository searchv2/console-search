# syntax=docker/dockerfile:1
#
#   docker build -t searchv2-console .
#   docker run --rm -it -e SEARCH_API_BASE_URL=http://host.docker.internal:5071 searchv2-console

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

ARG SEARCH_UTILITIES_REF=main
ADD https://github.com/searchv2/search-utilities.git#${SEARCH_UTILITIES_REF} /src/search-utilities
RUN dotnet pack /src/search-utilities/SearchUtilities.csproj -c Release -o /src/search-utilities/nupkg

WORKDIR /src/ConsoleSearch
COPY . .
RUN dotnet publish ConsoleSearch.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:10.0 AS runtime
WORKDIR /app
COPY --from=build /app .

# Base URL of the search service. The default suits `docker compose`; override
# for a standalone `docker run`.
ENV SEARCH_API_BASE_URL=http://search-api:8080

ENTRYPOINT ["dotnet", "ConsoleSearch.dll"]
