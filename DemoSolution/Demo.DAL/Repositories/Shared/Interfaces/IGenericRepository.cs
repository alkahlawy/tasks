using Demo.DAL.Models.Shared;
using System.Linq.Expressions;

namespace Demo.DAL.Repositories.Shared.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        void Add(TEntity entity);
        IEnumerable<TEntity> GetAll(bool withTracking = false);
        IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector, bool withTracking = false);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, bool withTracking = false);
        TEntity? GetByID(int id);
        void Remove(TEntity entity);
        void Update(TEntity entity);

        // Understood the difference between IEnumerable and IQueryable
        // IEnumerable<TEntity> GetIEnumerable();
        // IQueryable<TEntity> GetIQueryable();
    }
}
