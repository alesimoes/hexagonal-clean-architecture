using ANM.Example.Domain.User;
using System.Threading.Tasks;

namespace ANM.Example.Application.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserBy(int id);
        Task Add(User user);
    }
}
