using ANM.Example.Application.Abstractions.Services;
using ANM.Example.Repositories.MongoDb;
using System;
using System.Threading.Tasks;

namespace ANM.Example.Repositories.Context
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {

        private bool _disposed = false;
        private readonly AnmDbContext _context;
        private readonly TransactionDbContext _transactionContext;

        public UnitOfWork(AnmDbContext context, TransactionDbContext transactionContext)
        {
            this._context = context;
            this._transactionContext = transactionContext;

        }

        public async Task<int> Save()
        {
            int affectedRows = 0;
            affectedRows = await _context?.SaveChangesAsync();
            await this._transactionContext.SaveChangesAsync();
            return affectedRows;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }
    }
}
