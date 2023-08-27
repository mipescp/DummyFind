using DummyFind.Client.DummyApi.Models;
using DummyFind.Clients.DummyApi;
using DummyFind.Service.Models;
using DummyFind.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Concurrent;

var services = new ServiceCollection();

// Configure HttpClient
services.AddHttpClient<PostClient>();
services.AddHttpClient<TodosClient>();

// Add PostServices and PostClient
services.AddScoped<UserPostsService>();

var serviceProvider = services.BuildServiceProvider();

using (var scope = serviceProvider.CreateScope())
{
    var postsService = scope.ServiceProvider.GetRequiredService<UserPostsService>();

    var filteredPosts = await postsService.GetAllFilteredPostsAsync(post =>
       post.Reactions >= 1 && post.Tags.Contains("history"));

    var postsByUser = filteredPosts
        .GroupBy(post => post.UserId)
        .Select(group => new
        {
            UserId = group.Key,
            Posts = group.ToList()
        })
        .ToList();

    var concurrentDictionary = new ConcurrentDictionary<int, List<TodoDto>>();

    await Parallel.ForEachAsync(postsByUser, async (post, cancellationToken) =>
    {
        var userId = post.UserId.Value;
        var todosByUser = await postsService.GetAllTodosByUserId(userId);
        concurrentDictionary.TryAdd(userId, todosByUser);
    });

    var serviceRequest = postsByUser.Select(x => new UserDataDto
    {
        UserId = x.UserId.Value,
        Posts = x.Posts,
        Todos = concurrentDictionary[x.UserId.Value]
    })?.ToList();

    await postsService.InitializeDatabase(serviceRequest);

}