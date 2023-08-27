using DummyFind.Client.DummyApi.Models;
using DummyFind.Clients.DummyApi.Models;

namespace DummyFind.Service.Models
{
    public class UserDataDto
    {
        public int UserId { get; set; }
        public List<TodoDto> Todos { get; set; }
        public List<Post> Posts { get; set; }
    }
}
