
using DomainLayer.Contracts;
using DomainLayer.Models;
using PersistenceLayer.Data;

namespace PersistenceLayer.Repositories
{
    public class UnitOfWork(StoreDbContext _dbContext) : IUnitOfWork
    {
        private readonly Dictionary<string, object> _repositories = [];
        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            // Get the type of the requested repository
            var typeName = typeof(TEntity).Name;
            // Define a dictionary to hold repository instances

            //if (_repositories.ContainsKey(typeName))
            //{
            //    return (IGenericRepository<TEntity, TKey>)_repositories[typeName];
            //}

            if (_repositories.TryGetValue(typeName, out var repository))
            {
                return (IGenericRepository<TEntity, TKey>)repository;
            }
            else
            {
                var repositoryInstance = new GenericRepository<TEntity, TKey>(_dbContext);
                _repositories.Add(typeName, repositoryInstance);
                return repositoryInstance;
            }

        }

        public async Task<int> SaveChangesAsync()
            => await _dbContext.SaveChangesAsync();
    }
}
