﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CashMinder.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using CashMinder.Application.Interfaces.Repositories;
using CashMinder.Persistence.Repositories;
using CashMinder.Application.Interfaces.UnitOfWorks;
using CashMinder.Persistence.UnitOfWorks;
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

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
