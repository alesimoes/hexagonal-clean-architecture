using ANM.Core.Application.Abstractions.UseCase;
using ANM.Example.Application.Abstractions.Exceptions;

namespace ANM.Example.Application.UseCases.BuyStock
{
    public sealed class BuyStockInput : IUseCaseInput
    {
        public int WalletId { get; }
        public string Ticker { get; }
        public int Quantity { get; }
        public double Amount { get; }

        public BuyStockInput(int walletId, string ticker, int quantity, double amount)
        {
            this.WalletId = walletId;
            this.Ticker = ticker;
            this.Quantity = quantity;
            this.Amount = amount;
            this.Validate();
        }

        private void Validate()
        {
            if (this.WalletId < 1)
            {
                throw new ApplicationFieldValidationException($"Wallet identifier is invalid.");
            }

            if (string.IsNullOrEmpty(Ticker))
            {
                throw new ApplicationFieldValidationException($"Ticker is invalid.");
            }

            if (this.Amount <= 0)
            {
                throw new ApplicationFieldValidationException($"Invalid amount.");
            }

            if (this.Quantity < 1)
            {
                throw new ApplicationFieldValidationException($"Invalid quantity.");
            }
        }
    }
}
