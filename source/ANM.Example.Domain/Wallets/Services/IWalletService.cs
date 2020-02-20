namespace ANM.Example.Domain.Wallets.Services
{
    public interface IWalletService
    {
        void BuyStock(Wallet wallet, string ticker, int quantity, double amount);
        void SellStock(Wallet wallet, string ticker, int quantity, double amount);
    }
}
