using DummyFind.Client.DummyApi.Models;
using System.Net.Http.Json;

namespace DummyFind.Clients.DummyApi
{
    /// <summary>
    /// This Client classes should only be responsible for fetching external data using HttpClient
    /// </summary>
    /// <seealso cref="DummyFind.Clients.DummyApi.DummyApiClient" />
    public class TodosClient : DummyApiClient
    {
        public TodosClient(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<TodosResponse> GetTodosByUserIdAsync(int userId)
        {
            return await httpClient.GetFromJsonAsync<TodosResponse>($"/todos/user/{userId}");
        }
    }
}