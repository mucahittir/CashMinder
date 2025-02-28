using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CashMinder.Persistence.Seeds.Interfaces
{
    public interface ISeeder
    {
        int Order { get; }
        void Seed(DbContext context);
        Task SeedAsync(DbContext context, CancellationToken cancellationToken);
    }
}
