using ANM.Example.Domain.Transactions;
using System;

namespace ANM.Example.Application.UseCases.GetTransactions
{
    public class TransactionOutput
    {
        public string Id { get; protected set; }
        public string Ticker { get; protected set; }
        public int Quantity { get; protected set; }
        public double Amount { get; protected set; }
        public double Tax { get; protected set; }
        public bool OperationBuy { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
        public int WalletId { get; protected set; }

        internal TransactionOutput(Transaction transaction)
        {
            this.Id = transaction.TransactionId;
            this.Ticker = transaction.Ticker;
            this.Quantity = transaction.Quantity;
            this.Amount = transaction.Amount;
            this.Tax = transaction.Tax;
            this.OperationBuy = transaction.OperationBuy;
            this.CreatedDate = transaction.CreatedDate;
            this.WalletId = transaction.WalletId;
        }
    }
}
