using ANM.Core.Application.Abstractions.UseCase;
using ANM.Example.Application.Abstractions.Exceptions;
using System;

namespace ANM.Example.Application.UseCases.GetTransactions
{
    public sealed class GetTransactionsInput : IUseCaseInput
    {
        public GetTransactionsInput(int walletId, DateTime startDate, DateTime endDate)
        {
            this.WalletId = walletId;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Validate();
        }

        private void Validate()
        {
            if (this.WalletId < 1)
            {
                throw new ApplicationFieldValidationException($"Wallet identifier is invalid.");
            }
            if (this.EndDate < StartDate)
            {
                throw new ApplicationFieldValidationException($"Invalid date range");
            }
            if (this.EndDate.Subtract(StartDate).TotalDays > 90)
            {
                throw new ApplicationFieldValidationException($"Period cannot be greather than 90 days");
            }
        }
        public int WalletId { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
    }
}
