using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace PhucNPH.MockProject.Repository.Infrastructure.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> CreateAsync(T item);
        Task UpdateAsync(T item);
        Task<T?> SearchForSingleItemAsync(Expression<Func<T, bool>> searchExpression, params Expression<Func<T, object>>[] includes);
        Task<List<T>> SearchForMultipleItemAsync(Expression<Func<T, bool>>? searchExpression = null);
    }

    public abstract class Repository<TContext, T> : IRepository<T> where TContext : DbContext where T : class
    {
        protected readonly TContext DbContext;

        protected readonly DbSet<T> DbSet;

        public Repository(TContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        public virtual async Task<T> CreateAsync(T item)
        {
            await DbSet.AddAsync(item);
            return item;
        }

        public async Task<T?> SearchForSingleItemAsync
            (Expression<Func<T, bool>> searchExpression, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> queryable = EntityFrameworkQueryableExtensions.AsNoTracking(DbSet.Where(searchExpression));
            if (includes.Length != 0)
            {
                queryable = includes.Aggregate(queryable, (IQueryable<T> current, Expression<Func<T, object>> includeProperty) => EntityFrameworkQueryableExtensions.Include(current, includeProperty));
            }

            return await EntityFrameworkQueryableExtensions.SingleOrDefaultAsync(queryable);
        }

        public async Task UpdateAsync(T item)
        {
            DbSet.Update(item);
        }

        public async Task<List<T>> SearchForMultipleItemAsync(Expression<Func<T, bool>>? searchExpression)
        {
            return await EntityFrameworkQueryableExtensions.ToListAsync((searchExpression == null) ?
                EntityFrameworkQueryableExtensions.AsNoTracking(DbSet) :
                EntityFrameworkQueryableExtensions.AsNoTracking(DbSet.Where(searchExpression)));
        }
    }
}
