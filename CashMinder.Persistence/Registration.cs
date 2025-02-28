using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CashMinder.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using CashMinder.Application.Interfaces.Repositories;
using CashMinder.Persistence.Repositories;
using CashMinder.Application.Interfaces.UnitOfWorks;
using CashMinder.Persistence.UnitOfWorks;
using CashMinder.Domain.Entities;
using CashMinder.Persistence.Seeds;
using System.Reflection;
using CashMinder.Application.Bases;
namespace CashMinder.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 3;
                opt.SignIn.RequireConfirmedEmail = false;
            })
                .AddRoles<Role>()
                .AddEntityFrameworkStores<AppDbContext>();
        }
    }
}
