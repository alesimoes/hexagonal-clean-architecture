using ANM.Core.Domain.Abstractions.Events;
using ANM.Example.Domain.Stocks;
using ANM.Example.Domain.Wallets;

namespace ANM.Example.Domain.Transactions.Events
{
    public class TransactionCreatedDomainEvent : DomainEvent
    {
        public TransactionCreatedDomainEvent(Wallet source, Stock entity, bool operationBuy) : base()
        {
            this.Stock = entity;
            this.Wallet = source;
            this.OperationBuy = operationBuy;
        }

        public Stock Stock { get; }
        public Wallet Wallet { get; }

        public bool OperationBuy { get; }
        public static TransactionCreatedDomainEvent Create(Wallet source, Stock entity, bool operationBuy)
        {
            TransactionCreatedDomainEvent domainEvent = new TransactionCreatedDomainEvent(source, entity, operationBuy);
            return domainEvent;
        }
    }
}
