using ANM.Example.Application.UseCases.GetTransactions;
using System.Collections.Generic;

namespace ANM.Example.API.UseCases.GetTransactions
{
    public sealed class GetTransactionsResponse
    {


        public GetTransactionsResponse(List<TransactionOutput> transactions)
        {
            this.Transactions = transactions;
        }

        public List<TransactionOutput> Transactions { get; }
    }
}
