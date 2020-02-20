using ANM.Core.Application.Abstractions.UseCase;
using ANM.Example.Application.Abstractions.Exceptions;

namespace ANM.Example.Application.UseCases.GetWallet
{
    public sealed class GetWalletInput : IUseCaseInput
    {
        public GetWalletInput(int walletId)
        {
            this.WalletId = walletId;
            this.Validate();
        }

        private void Validate()
        {
            if (this.WalletId < 1)
            {
                throw new ApplicationFieldValidationException($"Wallet identifier is invalid.");
            }
        }

        public int WalletId { get; }
    }
}
