namespace DummyFind.Persistance
{
    public class PostsData
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string? UserName { get; set; }
        public bool HasFrenchTag { get; set; }
        public bool HasFictionTag { get; set; }
        public bool HasMoreThanTwoReactions { get; set; }
    }
}
