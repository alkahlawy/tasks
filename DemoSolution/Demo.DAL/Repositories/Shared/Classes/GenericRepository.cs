using System.Linq.Expressions;
using Demo.DAL.Data.Contexts;
using Demo.DAL.Models.Shared;
using Demo.DAL.Repositories.Shared.Interfaces;

namespace Demo.DAL.Repositories.Shared.Classes
{
    public class GenericRepository<TEntity>(ApplicationDbContext _context)
        :IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        public TEntity? GetByID(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }
        public IEnumerable<TEntity> GetAll(bool withTracking = false)
        {
            if (withTracking) return _context.Set<TEntity>().ToList();
            else return _context.Set<TEntity>().AsNoTracking().ToList();
        }
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }
        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
        public IEnumerable<TResult> GetAll<TResult>(
            Expression<Func<TEntity, TResult>> selector, 
            bool withTracking = false
            )
        {
            if (withTracking) 
                return _context.Set<TEntity>()
                               .Where(entity => entity.IsDeleted == false)
                               .Select(selector)
                               .ToList();
            else 
                return _context.Set<TEntity>()
                               .Where(entity => entity.IsDeleted == false)
                               .AsNoTracking()
                               .Select(selector)
                               .ToList();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, bool withTracking = false)
        {
            if (withTracking) 
                return _context.Set<TEntity>()
                               .Where(predicate)
                               .ToList();
            else 
                return _context.Set<TEntity>()
                               .AsNoTracking()
                               .Where(predicate)
                               .ToList();
        }
    }
}
