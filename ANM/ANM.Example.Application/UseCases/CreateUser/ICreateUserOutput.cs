using ANM.Example.Application.Abstractions.OutputPorts;

namespace ANM.Example.Application.UseCases.CreateUser
{
    public interface ICreateUserOutput : IOutputSuccess<CreateUserOutput>, IOutputFail
    {
    }
}
