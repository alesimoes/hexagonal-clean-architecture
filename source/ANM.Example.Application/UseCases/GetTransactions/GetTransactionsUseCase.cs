using ANM.Example.Application.Abstractions.Repositories;
using ANM.Example.Domain.Transactions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ANM.Example.Application.UseCases.GetTransactions
{
    public class GetTransactionsUseCase : IGetTransactionsUseCase
    {
        private readonly ITransactionRepository _repository;
        private readonly IGetTransactionsOutput _output;

        public GetTransactionsUseCase(ITransactionRepository transactionsReporitory,
            IGetTransactionsOutput output
            )
        {
            this._repository = transactionsReporitory;
            this._output = output;
        }

        public async Task Execute(GetTransactionsInput input)
        {
            var transactions = await this._repository.GetTransactions(input.WalletId, input.StartDate, input.EndDate);
            this.BuildOutput(transactions);
        }

        private void BuildOutput(List<Transaction> transactions)
        {
            if (transactions != null && transactions.Count > 0)
            {
                this._output.Ok(new GetTransactionsOutput(transactions));
            }
            else
            {
                this._output.Error("Transactions not found");
            }
        }
    }
}
