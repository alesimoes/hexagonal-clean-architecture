using ANM.Example.Domain.Stocks.Events;
using ANM.Example.Domain.Transactions.Events;
using System.Linq;

namespace ANM.Example.Domain.Stocks.Handlers
{
    internal class StockBougthDomainEventHandler
    {
        internal static void When(StockBougthDomainEvent @event)
        {
            var newStock = @event.Stock;
            var stock = @event.Wallet.Stocks?.FirstOrDefault(s => s.Ticker == newStock.Ticker);
            if (stock == null)
            {
                stock = newStock;
                @event.Wallet.Stocks.Add(stock);
            }
            else
            {
                stock.AddStock(newStock.Quantity, newStock.Amount);
            }

            @event.Wallet.Raise(TransactionCreatedDomainEvent.Create(@event.Wallet, newStock, true));
        }
    }
}
