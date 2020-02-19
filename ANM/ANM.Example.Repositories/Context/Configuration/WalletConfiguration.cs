using ANM.Example.Domain.Stocks;
using ANM.Example.Domain.Transactions;
using ANM.Example.Domain.Wallets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ANM.Example.Repositories.Context.Configuration
{
    public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.ToTable("Wallet");

            builder.Property(b => b.WalletId)
           .UseIdentityColumn()
           .IsRequired();
            builder.HasKey(c => c.WalletId);
            builder.HasMany<Stock>(b => b.Stocks).WithOne(s => s.Wallet).HasPrincipalKey(s => s.WalletId);

            // Uncomment this part if you want to see it working with EF
            //builder.HasMany<Transaction>(b => b.Transactions);

            // Comment this to map this table in EF
            builder.Ignore(i => i.Transactions);

        }
    }
}
