using ANM.Example.Domain.Wallets.Events;

namespace ANM.Example.Domain.Wallets.Handlers
{
    internal class WalletUpdatedDomainEventHandler
    {
        internal static void When(WalletUpdatedDomainEvent @event)
        {
            @event.Wallet.UpdateAmount();
        }
    }
}
