using DummyFind.Persistance;

namespace DummyFind.Repository
{
    public class UserDataRepository : IUserDataRepository
    {
        private readonly DummyFindDbContext _dbContext;

        public UserDataRepository(DummyFindDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUser(UserData user)
        {
            _dbContext.Users.Add(user);
        }

        public List<UserData> GetUsers()
        {
            return _dbContext.Users.ToList();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }

}
