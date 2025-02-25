using CashMinder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashMinder.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            builder.Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(c => c.UserId)
                .IsRequired();
            builder.HasOne(c => c.User)
                .WithMany(u => u.Categories)
                .HasForeignKey(c => c.UserId);


            builder.HasData(
                new Category
                {
                    Id = Guid.Parse("a1b2c3d4-1234-5678-9101-111213141516"), // Statik Guid
                    Name = "Eğlence",
                    UserId = Guid.Parse("50bb81ad-3b50-4b57-a677-080058ef5d96") // Statik UserId
                },
                new Category
                {
                    Id = Guid.Parse("b2c3d4e5-2345-6789-1011-121314151617"), // Statik Guid
                    Name = "Market",
                    UserId = Guid.Parse("50bb81ad-3b50-4b57-a677-080058ef5d96") // Statik UserId
                },
                new Category
                {
                    Id = Guid.Parse("c3d4e5f6-3456-7891-0111-213141516171"), // Statik Guid
                    Name = "Sağlık",
                    UserId = Guid.Parse("50bb81ad-3b50-4b57-a677-080058ef5d96") // Statik UserId
                },
                new Category
                {
                    Id = Guid.Parse("c3d4e5f6-3456-7891-0111-213141516132"), // Statik Guid
                    Name = "Ulaşım",
                    UserId = Guid.Parse("50bb81ad-3b50-4b57-a677-080058ef5d96") // Statik UserId
                },
                new Category
                {
                    Id = Guid.Parse("c3d4e5f6-3456-7891-0111-213141516103"), // Statik Guid
                    Name = "Diğer",
                    UserId = Guid.Parse("50bb81ad-3b50-4b57-a677-080058ef5d96") // Statik UserId
                }
            );
        }
    }
}
