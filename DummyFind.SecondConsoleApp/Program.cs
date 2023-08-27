using DummyFind.Clients.DummyApi;
using DummyFind.Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

// Configure HttpClient
services.AddHttpClient<PostClient>();

// Add PostServices and PostClient
services.AddScoped<UserPostsService>();

var serviceProvider = services.BuildServiceProvider();

using (var scope = serviceProvider.CreateScope())
{
    var postsService = scope.ServiceProvider.GetRequiredService<UserPostsService>();

    var filteredPosts = await postsService.GetAllFilteredPostsAsync(post =>
       post.Reactions >= 1 && post.Tags.Contains("history"));

    Dictionary<int, int> userData = new Dictionary<int, int>();
    foreach (var post in filteredPosts)
    {
        if (post == null || post.UserId == null) continue;

        if (!userData.ContainsKey(post.UserId.Value))
        {
            userData[post.UserId.Value] = 0;
        }
        userData[post.UserId.Value]++;
    }

    //using (var dbContext = new PostDbContext())
    //{
    //    dbContext.Database.EnsureCreated();

    //    foreach (var post in filteredPosts)
    //    {
    //        dbContext.Posts.Add(post);
    //    }

    //    await dbContext.SaveChangesAsync();
    //}

}