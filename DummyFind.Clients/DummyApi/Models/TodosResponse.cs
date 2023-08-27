using Newtonsoft.Json;

namespace DummyFind.Client.DummyApi.Models
{
    public class TodosResponse
    {
        [JsonProperty("todos")]
        public List<TodoDto> Todos { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("skip")]
        public int Skip { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }
    }

    public class TodoDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("todo")]
        public string? Todo { get; set; }

        [JsonProperty("completed")]
        public bool Completed { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }
    }


}
