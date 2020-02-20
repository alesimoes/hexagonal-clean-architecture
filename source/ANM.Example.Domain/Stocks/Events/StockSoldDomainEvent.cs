using ANM.Core.Domain.Abstractions.Events;
using ANM.Example.Domain.Wallets;

namespace ANM.Example.Domain.Stocks.Events
{
    public class StockSoldDomainEvent : DomainEvent
    {
        public Wallet Wallet { get; }
        public Stock Stock { get; }

        public StockSoldDomainEvent(Wallet wallet, Stock entity) : base()
        {
            this.Wallet = wallet;
            this.Stock = entity;
        }

        public static StockSoldDomainEvent Create(Wallet wallet, Stock entity)
        {
            StockSoldDomainEvent domainEvent = new StockSoldDomainEvent(wallet, entity);
            return domainEvent;
        }
    }
}
