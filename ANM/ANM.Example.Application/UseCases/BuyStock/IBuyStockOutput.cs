using ANM.Example.Application.Abstractions.OutputPorts;

namespace ANM.Example.Application.UseCases.BuyStock
{
    public interface IBuyStockOutput : IOutputSuccess<BuyStockOutput>, IOutputFail
    {
    }
}
