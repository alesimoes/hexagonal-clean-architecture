using System;

namespace ANM.Example.Domain.Transactions
{
    public class Transaction
    {
        public string TransactionId { get; protected set; }
        public string Ticker { get; protected set; }
        public int Quantity { get; protected set; }
        public double Amount { get; protected set; }
        public double Tax { get; protected set; }
        public bool OperationBuy { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
        public int WalletId { get; protected set; }

        private Transaction()
        {

        }

        internal static Transaction Create(int walletId, string ticker, int quantity, double amount, double tax, bool operationBuy)
        {
            var transcaction = new Transaction();
            transcaction.TransactionId = Guid.NewGuid().ToString();
            transcaction.WalletId = walletId;
            transcaction.Ticker = ticker;
            transcaction.Quantity = quantity;
            transcaction.Amount = amount;
            transcaction.Tax = tax;
            transcaction.OperationBuy = operationBuy;
            transcaction.CreatedDate = DateTime.UtcNow;
            return transcaction;
        }

    }
}
