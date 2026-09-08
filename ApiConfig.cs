namespace ConsoleSearch
{
    public class ApiConfig
    {
        public static readonly string SEARCH_API_BASE_URL =
            Environment.GetEnvironmentVariable("SEARCH_API_BASE_URL") ?? "http://localhost:5071";
    }
}
