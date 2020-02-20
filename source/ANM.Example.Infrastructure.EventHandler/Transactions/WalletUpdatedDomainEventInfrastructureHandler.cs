using ANM.Example.Application.Abstractions.Repositories;
using ANM.Example.Application.Abstractions.Services;
using ANM.Example.Domain.Wallets.Events;

namespace ANM.Example.Infrastructure.EventHandler
{
    public sealed class WalletUpdatedDomainEventInfrastructureHandler
    {
        private ITransactionRepository _repository;
        private IUnitOfWork _unitOfWork;

        public WalletUpdatedDomainEventInfrastructureHandler(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork)
        {
            this._repository = transactionRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Execute(WalletUpdatedDomainEvent @event)
        {
            var wallet = @event.Wallet;
            wallet.Apply(@event);
            this._repository.Add(@event.Transaction);
            this._unitOfWork.Save();
        }
    }
}
