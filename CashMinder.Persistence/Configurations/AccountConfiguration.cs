using CashMinder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashMinder.Persistence.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();
            builder.Property(a => a.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(a => a.Balance)
                .IsRequired();
            builder.Property(a => a.UserId)
                .IsRequired();
            builder.HasOne(a => a.User)
                .WithMany(u => u.Accounts)
                .HasForeignKey(a => a.UserId);


        }
    }
}
