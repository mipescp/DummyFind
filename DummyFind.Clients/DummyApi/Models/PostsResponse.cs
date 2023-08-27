using Newtonsoft.Json;

namespace DummyFind.Clients.DummyApi.Models
{
    public record Post(
        [property: JsonProperty("id")] int? Id,
        [property: JsonProperty("title")] string Title,
        [property: JsonProperty("body")] string Body,
        [property: JsonProperty("userId")] int? UserId,
        [property: JsonProperty("tags")] IEnumerable<string> Tags,
        [property: JsonProperty("reactions")] int? Reactions
    );

    public record PostsResponse(
        [property: JsonProperty("posts")] IEnumerable<Post> Posts,
        [property: JsonProperty("total")] int? Total,
        [property: JsonProperty("skip")] int? Skip,
        [property: JsonProperty("limit")] int? Limit
    );


}
