using ANM.Example.Application.Abstractions.Repositories;
using ANM.Example.Domain.Transactions;
using ANM.Example.Repositories.MongoDb;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ANM.Example.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly TransactionDbContext _context;

        public TransactionRepository(TransactionDbContext transactionDbContext)
        {
            this._context = transactionDbContext;
        }

        public async Task Add(Transaction transaction)
        {
            await _context.Transactions.InsertOneAsync(this._context.Session, transaction);
        }

        public Task<List<Transaction>> GetTransactions(int walletId, DateTime startDate, DateTime endDate)
        {
            return _context
                    .Transactions
                    .Find(f => f.WalletId == walletId && f.CreatedDate >= startDate && f.CreatedDate < endDate).ToListAsync();
        }
    }
}
