using ANM.Example.Application.Abstractions.Repositories;
using ANM.Example.Domain.User;
using ANM.Example.Repositories.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ANM.Example.Repositories
{

    public class UserRepository : IUserRepository
    {
        private readonly AnmDbContext _context;

        public UserRepository(AnmDbContext context)
        {
            this._context = context;
        }

        public async Task<User> GetUserBy(int id)
        {
            var user = await _context
                 .Users
                 .Where(a => a.UserId.Equals(id))
                 .SingleOrDefaultAsync();
            return user;
        }

        public async Task Add(User user)
        {
            await _context.AddAsync(user);
        }
    }
}
