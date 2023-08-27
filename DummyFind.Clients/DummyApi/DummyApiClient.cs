namespace DummyFind.Clients.DummyApi
{
    /// <summary>
    /// This Client classes should only be responsible for fetching external data using HttpClient.
    /// This is the base class to all api's that rely on DummyApi. Here we could leverage tricky stuff like 
    /// authentication, caching, etc...
    /// </summary>
    public class DummyApiClient
    {
        private const string UriString = "https://dummyjson.com/";
        protected readonly HttpClient httpClient;

        public DummyApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            httpClient.BaseAddress = new Uri(UriString);
        }
    }
}
