using ANM.Example.Domain.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ANM.Example.Repositories.Context.Configuration
{
    // Uncomment to have this one in EF database
    //    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    //    {
    //        public void Configure(EntityTypeBuilder<Transaction> builder)
    //        {

    //            builder.ToTable("Transaction");
    //            builder.HasKey(b => b.TransactionId);

    //        }
    //    }
}
