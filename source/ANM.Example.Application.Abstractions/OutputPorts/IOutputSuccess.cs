using ANM.Core.Application.Abstractions.UseCase;

namespace ANM.Example.Application.Abstractions.OutputPorts
{
    public interface IOutputSuccess<in TUseCaseOutput>
        where TUseCaseOutput : IUseCaseOutput
    {
        void Ok(TUseCaseOutput output);
    }
}
