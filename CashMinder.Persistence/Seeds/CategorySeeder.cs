using CashMinder.Domain.Entities;
using CashMinder.Persistence.Seeds.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CashMinder.Persistence.Seeds
{
    public class CategorySeeder : ISeeder
    {
        public int Order => 2;

        public void Seed(DbContext context)
        {
            var user = context.Set<User>().FirstOrDefault(u => u.UserName == "admin");
            if (user != null && !context.Set<Category>().Any(c => c.Name == "DefaultCategory"))
            {
                List<Category> categories = new List<Category>
                {
                    new() {Id = Guid.NewGuid(),Name = "Eğlence",UserId = user.Id, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow},
                    new() {Id = Guid.NewGuid(),Name = "Market",UserId = user.Id, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow},
                    new() {Id = Guid.NewGuid(),Name = "Sağlık",UserId = user.Id, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow},
                    new() {Id = Guid.NewGuid(),Name = "Kira",UserId = user.Id, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow},
                    new() {Id = Guid.NewGuid(),Name = "Ulaşım",UserId = user.Id, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow},
                    new() {Id = Guid.NewGuid(),Name = "Diğer",UserId = user.Id, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow},
                };
                context.Set<Category>().AddRange(categories);
                context.SaveChanges();
            }
            
        }
        public async Task SeedAsync(DbContext context, CancellationToken cancellationToken)
        {
            var user = await context.Set<User>().FirstOrDefaultAsync(u => u.UserName == "admin");
            if (user != null && !await context.Set<Category>().AnyAsync(c => c.Name == "DefaultCategory"))
            {
                List<Category> categories = new List<Category>
                {
                    new() {Id = Guid.NewGuid(), Name = "Eğlence", UserId = user.Id, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow},
                    new() {Id = Guid.NewGuid(), Name = "Market", UserId = user.Id, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow},
                    new() {Id = Guid.NewGuid(), Name = "Sağlık", UserId = user.Id, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow},
                    new() {Id = Guid.NewGuid(), Name = "Kira", UserId = user.Id, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow},
                    new() {Id = Guid.NewGuid(), Name = "Ulaşım", UserId = user.Id, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow},
                    new() {Id = Guid.NewGuid(), Name = "Diğer", UserId = user.Id, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow},
                };
                context.Set<Category>().AddRange(categories);
                await context.SaveChangesAsync();
            }
        }
    }
}
