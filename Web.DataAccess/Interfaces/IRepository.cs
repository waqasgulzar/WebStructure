using System.Linq.Expressions;

namespace Web.DataAccess.Interfaces
{
    public interface IRepository<TEntity, in TPrimaryKeyType> where TEntity : class
    {
        ValueTask<TEntity> GetByIdAsync(TPrimaryKeyType id);
        ValueTask<TEntity> GetByIdAsync(string id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        int Count();

    }
}
