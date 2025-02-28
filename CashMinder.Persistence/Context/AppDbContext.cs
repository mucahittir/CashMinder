using System.Reflection;
using CashMinder.Domain.Entities;
using CashMinder.Persistence.Seeds.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CashMinder.Persistence.Context
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public AppDbContext()
        {
            
        }
        DbSet<Account> Accounts { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Transaction> Transactions { get; set; }
        DbSet<RecurringTransaction> RecurringTransactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var seeders = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => typeof(ISeeder).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                .Select(type => (ISeeder)Activator.CreateInstance(type))
                .OrderBy(seeder => seeder.Order);

            optionsBuilder.UseSeeding((context, _) =>
            {
                foreach (var seeder in seeders)
                {
                    seeder.Seed((AppDbContext)context);
                }
            })
            .UseAsyncSeeding(async (context, _, cancellationToken) =>
            {

                foreach (var seeder in seeders)
                {
                    await seeder.SeedAsync((AppDbContext)context, cancellationToken);
                }
            });
        }

    }
}
