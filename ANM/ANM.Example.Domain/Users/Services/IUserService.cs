using ANM.Example.Domain.ValueObjects;

namespace ANM.Example.Domain.User.Services
{
    public interface IUserService
    {
        User CreateUser(Name name, Email email);
    }
}
