using ANM.Core.Application.Abstractions.UseCase;
using ANM.Example.Domain.Wallets;
using System.Collections.Generic;
using System.Linq;

namespace ANM.Example.Application.UseCases.GetWallet
{
    public sealed class GetWalletOutput : IUseCaseOutput
    {
        internal GetWalletOutput(Wallet wallet)
        {
            this.WalletId = wallet.WalletId;
            this.Amount = wallet.AmountInvested;
            this.Stocks = wallet.Stocks.Select(s => new StockOutput(s)).ToList();
        }

        public int WalletId { get; }
        public double Amount { get; }
        public IList<StockOutput> Stocks { get; }
    }
}
