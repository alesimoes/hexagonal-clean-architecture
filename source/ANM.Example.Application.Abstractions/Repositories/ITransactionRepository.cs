using ANM.Example.Domain.Transactions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ANM.Example.Application.Abstractions.Repositories
{
    public interface ITransactionRepository
    {
        Task<List<Transaction>> GetTransactions(int walletId, DateTime startDate, DateTime endDate);

        Task Add(Transaction transaction);
    }
}
