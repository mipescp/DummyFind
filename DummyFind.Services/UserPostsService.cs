using DummyFind.Client.DummyApi.Models;
using DummyFind.Clients.DummyApi;
using DummyFind.Clients.DummyApi.Models;
using DummyFind.Repository;
using DummyFind.Service.Models;

namespace DummyFind.Services
{
    /// <summary>
    /// This is the layer where business logic should be. It can call external api's (Clients), 
    /// or query database (Repository)
    /// </summary>
    public class UserPostsService
    {
        private readonly PostClient _postClient;
        private readonly TodosClient _todosClient;
        private readonly IUserDataRepository _userDataRepository;

        public UserPostsService(
            PostClient postClient, TodosClient todosClient, IUserDataRepository userDataRepository)
        {
            _postClient = postClient ?? throw new ArgumentNullException(nameof(postClient));
            _todosClient = todosClient ?? throw new ArgumentNullException(nameof(todosClient));
            this._userDataRepository = userDataRepository;
        }

        /// <summary>
        /// Gets all filtered posts asynchronous.
        /// </summary>
        /// <param name="filterPredicate">The filter predicate.</param>
        /// <param name="query">The query.</param>
        /// <returns>Returns empty list if no results were found</returns>
        public async Task<List<Post>> GetAllFilteredPostsAsync(Func<Post, bool> filterPredicate, Dictionary<string, string>? query = default)
        {
            var posts = await _postClient.GetPostsAsync(new Dictionary<string, string> {
                { "limit", "0" }
            });

            return posts?.Posts?.Where(filterPredicate)?.ToList() ?? new List<Post>();
        }

        /// <summary>
        /// Gets all todos by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public async Task<List<TodoDto>> GetAllTodosByUserId(int userId)
        {
            return (await _todosClient.GetTodosByUserIdAsync(userId))?.Todos;
        }


        public async Task InitializeDatabase(List<UserDataDto> userDataDtos)
        {
            await Parallel.ForEachAsync(userDataDtos, async (userData, cancellationToken) =>
            {
                _userDataRepository.AddUser(new Persistance.UserData
                {
                    UserId = userData.UserId,
                    NumberOfPosts = userData.Posts.Count,
                    NumberOfTodos = userData.Todos.Count,
                });
            });

            _userDataRepository.SaveChanges();
        }

    }
}