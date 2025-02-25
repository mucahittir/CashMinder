using System.Reflection;
using CashMinder.Application.Interfaces.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace CashMinder.Mapper
{
    public static class Registration
    {
        public static void AddMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, AutoMapper.Mapper>();
        }
    }
}
