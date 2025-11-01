
using DomainLayer.Models;

namespace DomainLayer.Contracts
{
    public interface IUnitOfWork
    {
        // when call GetRepository, it will return the repository for the specified entity type
        // var repo = unitOfWork.GetRepository<MyEntity, int>();
        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() 
            where TEntity : BaseEntity<TKey>;
    
        Task<int> SaveChangesAsync();
    }
}
