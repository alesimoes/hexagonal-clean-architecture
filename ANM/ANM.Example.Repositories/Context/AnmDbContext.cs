using ANM.Example.Domain.Stocks;
using ANM.Example.Domain.Transactions;
using ANM.Example.Domain.User;
using ANM.Example.Domain.Wallets;
using Microsoft.EntityFrameworkCore;


namespace ANM.Example.Repositories.Context
{
    public sealed class AnmDbContext : DbContext
    {
        public AnmDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // coment this line to add transaction table in EF
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AnmDbContext).Assembly);


        }

        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Stock> Stocks { get; set; }
    }
}
