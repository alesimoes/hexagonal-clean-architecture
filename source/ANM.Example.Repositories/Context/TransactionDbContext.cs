using ANM.Example.Domain.Transactions;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace ANM.Example.Repositories.MongoDb
{
    public class TransactionDbContext : IDisposable
    {
        private readonly IMongoDatabase _db;
        private readonly IClientSessionHandle _session;
        private bool _disposed;

        public TransactionDbContext(MongoDBConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);
            this._session = client.StartSession();
            this._session.StartTransaction();
        }
        public IMongoCollection<Transaction> Transactions => _db.GetCollection<Transaction>("Transactions");

        internal IClientSessionHandle Session => _session;

        public async Task SaveChangesAsync()
        {
            await this.Session.CommitTransactionAsync();
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
                    this.Session.Dispose();
                }
            }

            _disposed = true;
        }
    }
}
