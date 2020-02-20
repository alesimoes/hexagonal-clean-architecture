using ANM.Core.Application.Abstractions.UseCase;
using ANM.Example.Domain.User;
using ANM.Example.Domain.ValueObjects;

namespace ANM.Example.Application.UseCases.CreateUser
{
    public sealed class CreateUserOutput : IUseCaseOutput
    {
        internal CreateUserOutput(User user)
        {
            this.Name = user.Name;
            this.Id = user.UserId;
            this.WalletId = user.Wallet.WalletId;
        }

        public Name Name { get; }
        public int? Id { get; }
        public int WalletId { get; }
    }
}
