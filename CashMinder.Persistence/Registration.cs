using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CashMinder.Persistence.Context;
using Microsoft.EntityFrameworkCore;
namespace CashMinder.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
