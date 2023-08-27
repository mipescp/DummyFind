using DummyFind.Persistance;

namespace DummyFind.Repository
{
    public class PostsDataRepository : IPostsDataRepository
    {
        private readonly DummyFindDbContext _dbContext;

        public PostsDataRepository(DummyFindDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddPost(PostsData post)
        {
            _dbContext.Posts.Add(post);
        }

        public List<PostsData> GetPosts()
        {
            return _dbContext.Posts.ToList();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }

}
