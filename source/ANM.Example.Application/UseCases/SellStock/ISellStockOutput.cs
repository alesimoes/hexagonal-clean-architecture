using ANM.Example.Application.Abstractions.OutputPorts;

namespace ANM.Example.Application.UseCases.SellStock
{
    public interface ISellStockOutput : IOutputSuccess<SellStockOutput>, IOutputFail
    {
    }
}
