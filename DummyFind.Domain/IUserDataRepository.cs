using DummyFind.Persistance;

namespace DummyFind.Repository
{
    public interface IUserDataRepository
    {
        void AddUser(UserData user);
        List<UserData> GetUsers();
        void SaveChanges();
    }
}