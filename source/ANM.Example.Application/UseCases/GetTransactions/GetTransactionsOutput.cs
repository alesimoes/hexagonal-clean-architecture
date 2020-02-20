using ANM.Core.Application.Abstractions.UseCase;
using ANM.Example.Domain.Transactions;
using System.Collections.Generic;
using System.Linq;

namespace ANM.Example.Application.UseCases.GetTransactions
{
    public sealed class GetTransactionsOutput : IUseCaseOutput
    {
        internal GetTransactionsOutput(List<Transaction> transactions)
        {
            this.Transactions = transactions.Select(s => new TransactionOutput(s)).ToList();
        }

        public List<TransactionOutput> Transactions { get; }
    }
}
