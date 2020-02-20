using System;
using ANM.Example.Domain.Wallets;

namespace ANM.Example.Domain.Stocks
{
    public class Stock
    {
        public string StockId { get; protected set; }
        public string Ticker { get; protected set; }
        public int Quantity { get; protected set; }
        public double Amount { get; protected set; }
        public Wallet Wallet { get; protected set; }

        private Stock()
        {

        }

        internal static Stock Create(Wallet wallet, string ticker, int quantity, double amount)
        {
            var stock = new Stock();
            stock.StockId = Guid.NewGuid().ToString();
            stock.Wallet = wallet;
            stock.Ticker = ticker;
            stock.Quantity = quantity;
            stock.Amount = amount;
            return stock;
        }

        internal void AddStock(int quantity, double amount)
        {
            this.Amount = ((this.Amount * this.Quantity) + (amount * quantity)) / (this.Quantity + quantity);
            this.Quantity = this.Quantity + quantity;
        }

        internal void SellStock(int quantity)
        {
            this.Quantity = this.Quantity - quantity;
        }
    }
}
