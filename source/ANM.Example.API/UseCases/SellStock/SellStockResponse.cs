using System;

namespace ANM.Example.API.UseCases.SellStock
{
    public class SellStockResponse
    {
        public SellStockResponse(string id, string ticker, int quantity, double amount)
        {
            this.Id = id;
            this.Ticker = ticker;
            this.Quantity = quantity;
            this.Amount = amount;
        }

        public string Id { get; }
        public string Ticker { get; }
        public int Quantity { get; }
        public double Amount { get; }
    }
}
