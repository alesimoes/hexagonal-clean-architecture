using ANM.Core.Domain.Abstractions.Events;
using ANM.Example.Domain.Transactions;

namespace ANM.Example.Domain.Wallets.Events
{
    public class WalletUpdatedDomainEvent : DomainEvent
    {
        public Wallet Wallet { get; }
        public Transaction Transaction { get; }

        public WalletUpdatedDomainEvent(Wallet wallet, Transaction transaction) : base()
        {
            this.Wallet = wallet;
            this.Transaction = transaction;
        }

        public static WalletUpdatedDomainEvent Create(Wallet wallet, Transaction transaction)
        {
            WalletUpdatedDomainEvent domainEvent = new WalletUpdatedDomainEvent(wallet, transaction);
            return domainEvent;
        }
    }
}
