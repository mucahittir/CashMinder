using CashMinder.Application.Interfaces.Repositories;
using CashMinder.Application.Interfaces.UnitOfWorks;
using CashMinder.Persistence.Context;
using CashMinder.Persistence.Repositories;

namespace CashMinder.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public ValueTask DisposeAsync() => dbContext.DisposeAsync();

        public int Save() => dbContext.SaveChanges();

        public Task<int> SaveAsync() => dbContext.SaveChangesAsync();

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(dbContext);

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(dbContext);
    }
}
