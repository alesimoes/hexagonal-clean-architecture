using ANM.Example.Application.Abstractions.OutputPorts;

namespace ANM.Example.Application.UseCases.GetTransactions
{
    public interface IGetTransactionsOutput : IOutputSuccess<GetTransactionsOutput>, IOutputFail
    {
    }
}
