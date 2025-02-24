using CashMinder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashMinder.Persistence.Configurations
{
    public class RecurringTransactionConfiguration : IEntityTypeConfiguration<RecurringTransaction>
    {
        public void Configure(EntityTypeBuilder<RecurringTransaction> builder)
        {
            builder.HasOne(rt => rt.Account)
                .WithMany(a => a.RecurringTransactions)
                .HasForeignKey(rt => rt.AccountId);
            builder.HasOne(rt => rt.Category)
                .WithMany(c => c.RecurringTransactions)
                .HasForeignKey(rt => rt.CategoryId);
            builder.HasOne(rt => rt.User)
                .WithMany(u => u.RecurringTransactions)
                .HasForeignKey(rt => rt.UserId);
        }
    }
}
