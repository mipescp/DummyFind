using DummyFind.Persistance;

namespace DummyFind.Repository
{
    public interface IPostsDataRepository
    {
        void AddPost(PostsData post);
        List<PostsData> GetPosts();
        void SaveChanges();
    }
}