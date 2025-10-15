using System.Linq.Expressions;
using Demo.DAL.Data.Contexts;
using Demo.DAL.Models.Shared;

namespace Demo.DAL.Repositories.Shared
{
    public class GeneticRepository<TEntity>(ApplicaionDbContext _context)
        :IGeneticRepository<TEntity> where TEntity : BaseEntity
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
        public int Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return _context.SaveChanges();
        }
        public int Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return _context.SaveChanges();
        }
        public int Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return _context.SaveChanges();
        }

        public IEnumerable<TEntity> GetIEnumerable()
        {
            return _context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetIQueryable()
        {
            return _context.Set<TEntity>();
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
    }
}
