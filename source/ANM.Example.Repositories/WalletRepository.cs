using ANM.Example.Application.Abstractions.Repositories;
using ANM.Example.Domain.Wallets;
using ANM.Example.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ANM.Example.Repositories
{

    public class WalletRepository : IWalletRepository
    {
        private readonly AnmDbContext _context;

        public WalletRepository(AnmDbContext context)
        {
            this._context = context;
        }

        public async Task<Wallet> GetWalletBy(int id)
        {
            var wallet = await _context
                 .Wallets
                 .Where(a => a.WalletId.Equals(id)).Include(f => f.Stocks)
                 .SingleOrDefaultAsync();
            return wallet;
        }
    }
}
