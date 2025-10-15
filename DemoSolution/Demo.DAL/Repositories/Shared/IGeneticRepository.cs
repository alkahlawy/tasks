using Demo.DAL.Models.Shared;
using System.Linq.Expressions;

namespace Demo.DAL.Repositories.Shared
{
    public interface IGeneticRepository<TEntity> where TEntity : BaseEntity
    {
        int Add(TEntity entity);
        IEnumerable<TEntity> GetAll(bool withTracking = false);
        IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector, bool withTracking = false);
        TEntity? GetByID(int id);
        int Remove(TEntity entity);
        int Update(TEntity entity);

        // Understood the difference between IEnumerable and IQueryable
        // IEnumerable<TEntity> GetIEnumerable();
        // IQueryable<TEntity> GetIQueryable();
    }
}
