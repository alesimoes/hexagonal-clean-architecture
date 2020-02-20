using ANM.Example.Domain.User;
using ANM.Example.Domain.ValueObjects;
using ANM.Example.Domain.Wallets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ANM.Example.Repositories.Context.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.Property(b => b.UserId)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(b => b.Name)
                .HasConversion(
                    v => v.ToString(),
                    v => new Name(v))
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(b => b.Email)
             .HasConversion(
                 v => v.ToString(),
                 v => new Email(v))
             .HasMaxLength(200)
             .IsRequired();
            builder.HasKey(c => c.UserId);
            builder.HasOne<Wallet>(b => b.Wallet).WithOne(u => u.User).HasForeignKey<Wallet>(f => f.UserId);
        }
    }
}
