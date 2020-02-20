using ANM.Example.Domain.Transactions.Events;
using ANM.Example.Domain.Wallets.Events;

namespace ANM.Example.Domain.Transactions.Handlers
{
    internal class TransactionCreatedDomainEventHandler
    {
        internal static void When(TransactionCreatedDomainEvent @event)
        {
            var stock = @event.Stock;
            var transaction = Transaction.Create(@event.Wallet.WalletId, stock.Ticker, stock.Quantity, stock.Amount, 10.50, @event.OperationBuy);

            @event.Wallet.Transactions.Add(transaction);
            @event.Wallet.Raise(WalletUpdatedDomainEvent.Create(@event.Wallet, transaction));
        }
    }
}
