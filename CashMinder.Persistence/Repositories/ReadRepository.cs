using System.Linq.Expressions;
using CashMinder.Application.Interfaces.Repositories;
using CashMinder.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
namespace CashMinder.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class, IEntityBase, new()
    {
        private readonly DbContext dbContext;
        private DbSet<T> entities => dbContext.Set<T>();
        public ReadRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
                                               Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                               Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                               bool enableTracking = false)
        {
            IQueryable<T> queryable = entities;

            if(!enableTracking) queryable = queryable.AsNoTracking();
            if(include != null) queryable = include(queryable);
            if(predicate != null) queryable = queryable.Where(predicate);

            if(orderBy != null)
                return await orderBy(queryable).ToListAsync();
            return await queryable.ToListAsync();
        }
        public async Task<List<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null,
                                                 Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                                 Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                                 bool enableTracking = false,
                                                 int currentPage = 1,
                                                 int pageSize = 10)
        {
            IQueryable<T> queryable = entities;

            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);

            if (orderBy != null)
                return await orderBy(queryable).Skip(currentPage - 1 * pageSize).Take(pageSize).ToListAsync();
            return await queryable.Skip(currentPage - 1 * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = entities;

            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            return await queryable.FirstOrDefaultAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate)
        {
            entities.AsNoTracking();
            if(predicate != null)
                return await entities.CountAsync(predicate);
            return await entities.CountAsync();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking)
        {
            if (enableTracking)
                entities.AsNoTracking();

            return entities.Where(predicate);
        }


        

    }
}
