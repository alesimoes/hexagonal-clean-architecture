using ANM.Core.Domain.Abstractions.Events;
using ANM.Example.Domain.Wallets;

namespace ANM.Example.Domain.Stocks.Events
{
    public class StockBougthDomainEvent : DomainEvent
    {

        public StockBougthDomainEvent(Wallet source, Stock entity) : base()
        {
            this.Wallet = source;
            this.Stock = entity;
        }

        public Wallet Wallet { get; }
        public Stock Stock { get; }

        public static StockBougthDomainEvent Create(Wallet source, Stock entity)
        {
            StockBougthDomainEvent domainEvent = new StockBougthDomainEvent(source, entity);
            return domainEvent;
        }
    }
}
