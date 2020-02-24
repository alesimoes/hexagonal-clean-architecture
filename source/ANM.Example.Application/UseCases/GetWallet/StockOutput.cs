using System;
using ANM.Example.Domain.Stocks;

namespace ANM.Example.Application.UseCases.GetWallet
{
    public class StockOutput
    {
        public string Id { get; protected set; }
        public string Ticker { get; protected set; }
        public int Quantity { get; protected set; }
        public double Amount { get; protected set; }
        public int WalletId { get; protected set; }

        internal StockOutput(Stock stock)
        {
            this.Id = stock.StockId;
            this.Ticker = stock.Ticker;
            this.Quantity = stock.Quantity;
            this.Amount = stock.Amount;
            this.WalletId = stock.Wallet.WalletId;
        }
    }
}
