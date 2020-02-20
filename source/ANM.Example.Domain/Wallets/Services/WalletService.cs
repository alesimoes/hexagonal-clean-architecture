namespace ANM.Example.Domain.Wallets.Services
{
    public class WalletService : IWalletService
    {
        public void BuyStock(Wallet wallet, string ticker, int quantity, double amount)
        {
            wallet.BuyStock(ticker, quantity, amount);
        }

        public void SellStock(Wallet wallet, string ticker, int quantity, double amount)
        {
            wallet.SellStock(ticker, quantity, amount);
        }
    }
}
