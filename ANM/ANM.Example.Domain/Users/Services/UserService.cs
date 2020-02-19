using ANM.Example.Domain.ValueObjects;

namespace ANM.Example.Domain.User.Services
{
    public sealed class UserService : IUserService
    {
        public User CreateUser(Name name, Email email)
        {
            var user = User.Create(name, email);
            return user;
        }
    }
}
