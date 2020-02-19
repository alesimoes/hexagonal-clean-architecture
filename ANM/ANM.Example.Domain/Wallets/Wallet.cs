using ANM.Core.Domain.Abstractions.Events;
using ANM.Example.Domain.Stocks;
using ANM.Example.Domain.Stocks.Events;
using ANM.Example.Domain.Stocks.Handlers;
using ANM.Example.Domain.Transactions;
using ANM.Example.Domain.Transactions.Events;
using ANM.Example.Domain.Transactions.Handlers;
using ANM.Example.Domain.Wallets.Events;
using ANM.Example.Domain.Wallets.Exceptions;
using ANM.Example.Domain.Wallets.Handlers;
using System.Collections.Generic;
using System.Linq;

namespace ANM.Example.Domain.Wallets
{
    public class Wallet : AggregateRoot
    {
        public int WalletId { get; protected set; }
        public int UserId { get; protected set; }
        public User.User User { get; protected set; }
        public IList<Stock> Stocks { get; protected set; }
        public IList<Transaction> Transactions { get; protected set; }
        public double AmountInvested { get; protected set; }
        public double Amount { get; protected set; }

        private Wallet()
        {
            Register<StockBougthDomainEvent>(StockBougthDomainEventHandler.When);
            Register<StockSoldDomainEvent>(StockSoldDomainEventHandler.When);
            Register<TransactionCreatedDomainEvent>(TransactionCreatedDomainEventHandler.When);
            Register<WalletUpdatedDomainEvent>(WalletUpdatedDomainEventHandler.When);
        }

        internal static Wallet Create(User.User user)
        {
            var wallet = new Wallet();
            wallet.Stocks = new List<Stock>();
            wallet.Transactions = new List<Transaction>();
            wallet.User = user;
            return wallet;
        }

        internal void BuyStock(string ticker, int quantity, double amount)
        {
            var newStock = Stock.Create(this, ticker, quantity, amount);
            if (this.Stocks == null)
            {
                this.Stocks = new List<Stock>();
            }
            if (this.Transactions == null)
            {
                this.Transactions = new List<Transaction>();
            }
            if (newStock.Quantity < 1)
            {
                throw new StockException("Quantity informed is invalid");
            }
            if (newStock.Amount < 0)
            {
                throw new StockException("Invalid amount");
            }
            Raise(StockBougthDomainEvent.Create(this, newStock));
        }

        internal void SellStock(string ticker, int quantity, double amount)
        {
            var newStock = Stock.Create(this, ticker, quantity, amount);
            var stock = this.Stocks?.FirstOrDefault(s => s.Ticker == newStock.Ticker);
            if (stock == null)
            {
                throw new StockException("Ticker not found");
            }
            if (stock.Quantity < newStock.Quantity)
            {
                throw new StockException("Quantity informed is invalid");
            }
            if (newStock.Amount < 0)
            {
                throw new StockException("Invalid amount");
            }
            if (this.Transactions == null)
            {
                this.Transactions = new List<Transaction>();
            }
            Raise(StockSoldDomainEvent.Create(this, newStock));
        }

        internal void UpdateAmount()
        {
            this.AmountInvested = this.Stocks.Sum(s => s.Amount * s.Quantity);
        }
    }
}
