using CashMinder.Domain.Entities;
using CashMinder.Persistence.Seeds.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CashMinder.Persistence.Seeds
{
    public class UserSeeder : ISeeder
    {
        public int Order => 1;

        public void Seed(DbContext context)
        {
            var hasher = new PasswordHasher<User>();

            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Admin",
                LastName = "User",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                UserName = "admin",
                NormalizedUserName = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            user.PasswordHash = hasher.HashPassword(user, "123");

            if (!context.Set<User>().Any())
            {
                context.Set<User>().Add(user);
                context.SaveChanges();
            }
        }

        public async Task SeedAsync(DbContext context, CancellationToken cancellationToken)
        {
            var hasher = new PasswordHasher<User>();

            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Admin",
                LastName = "User",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                UserName = "admin",
                NormalizedUserName = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            user.PasswordHash = hasher.HashPassword(user, "123");

            if (!await context.Set<User>().AnyAsync(cancellationToken))
            {
                await context.Set<User>().AddAsync(user, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
