using ANM.Example.Application.UseCases.GetWallet;
using System.Collections.Generic;
using System.Linq;

namespace ANM.Example.API.UseCases.GetWallet
{
    public class GetWalletResponse
    {
        public double Amount { get; protected set; }
        public GetWalletResponse(IList<StockOutput> stocks, double amount)
        {
            this.Amount = amount;
            this.Stocks = stocks.ToList();
        }

        public List<StockOutput> Stocks { get; }
    }
}
