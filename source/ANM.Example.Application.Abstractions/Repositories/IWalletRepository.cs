using ANM.Example.Domain.Wallets;
using System.Threading.Tasks;

namespace ANM.Example.Application.Abstractions.Repositories
{

    public interface IWalletRepository
    {
        Task<Wallet> GetWalletBy(int id);
    }

}
