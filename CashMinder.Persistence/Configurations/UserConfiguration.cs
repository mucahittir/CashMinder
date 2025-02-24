using CashMinder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashMinder.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();
            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                new User
                {
                    Id = new Guid("50bb81ad-3b50-4b57-a677-080058ef5d96"),
                    Username = "mucahittir",
                    FirstName = "Mucahit",
                    LastName = "Tiryaki",
                    Email = "mucahit@bisiler.com",
                    PasswordHash = "hashed_password_1"
                },
                new User
                {
                    Id = new Guid("e75e1e79-eb5d-42c4-b28a-01eebf7b9554"),
                    Username = "johndoe",
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john@example.com",
                    PasswordHash = "hashed_password_1"
                }
            );
        }
    }
}
