using DummyFind.Clients.DummyApi;
using DummyFind.Clients.DummyApi.Models;
using Moq;
using Newtonsoft.Json;
using System.Net;

namespace DummyFind.PostClientTests
{
    [TestClass]
    public class PostClientTests
    {
        [TestMethod]
        public async Task GetPostsAsync_ReturnsPosts()
        {
            // Arrange
            var mockHttpClient = new Mock<HttpClient>();
            var fakePosts = new PostsResponse(new List<Post> { new Post(1, "Test Post", null, 1, null, 0) }, 1, 0, 0);

            mockHttpClient.Setup(client => client.GetAsync(It.IsAny<string>()))
                                  .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent(JsonConvert.SerializeObject(fakePosts)) });

            var postClient = new PostClient(mockHttpClient.Object);

            // Act
            var posts = await postClient.GetPostsAsync();

            // Assert
            Assert.IsNotNull(posts);
            Assert.AreEqual(1, posts.Posts.Count());
            Assert.AreEqual("Test Post", posts.Posts.FirstOrDefault().Title);
        }
    }

}