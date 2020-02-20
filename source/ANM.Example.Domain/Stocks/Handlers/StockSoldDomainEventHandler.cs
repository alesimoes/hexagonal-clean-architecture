using ANM.Example.Domain.Stocks.Events;
using ANM.Example.Domain.Transactions.Events;
using System.Linq;

namespace ANM.Example.Domain.Stocks.Handlers
{
    internal class StockSoldDomainEventHandler
    {
        internal static void When(StockSoldDomainEvent @event)
        {
            var newStock = (Stock)@event.Stock;
            var stock = @event.Wallet.Stocks?.FirstOrDefault(s => s.Ticker == newStock.Ticker);

            if (stock.Quantity == newStock.Quantity)
            {
                @event.Wallet.Stocks.Remove(stock);
            }
            else
            {
                stock.SellStock(newStock.Quantity);
            }

            @event.Wallet.Raise(TransactionCreatedDomainEvent.Create(@event.Wallet, newStock, false));
        }
    }
}
