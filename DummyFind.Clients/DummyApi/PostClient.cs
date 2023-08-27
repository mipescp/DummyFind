using DummyFind.Clients.DummyApi.Models;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Json;

namespace DummyFind.Clients.DummyApi
{
    /// <summary>
    /// This Client classes should only be responsible for fetching external data using HttpClient
    /// </summary>
    /// <seealso cref="DummyFind.Clients.DummyApi.DummyApiClient" />
    public class PostClient : DummyApiClient
    {
        public PostClient(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<PostsResponse> GetPostsAsync(Dictionary<string, string>? query = default)
        {
            return await httpClient.GetFromJsonAsync<PostsResponse>(QueryHelpers.AddQueryString("posts", query));
        }
    }
}