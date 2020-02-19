using ANM.Example.Application.Abstractions.OutputPorts;

namespace ANM.Example.Application.UseCases.GetWallet
{
    public interface IGetWalletOutput : IOutputSuccess<GetWalletOutput>, IOutputFail
    {
    }
}
