
using Demo.DAL.Models.EmployeeModel;
using Demo.DAL.Models.Shared;

namespace Demo.DAL.Repositories.Shared
{
    public interface IGeneticRepository<TEntity> where TEntity : BaseEntity
    {
        int Add(TEntity entity);
        IEnumerable<TEntity> GetAll(bool withTracking = false);
        TEntity? GetByID(int id);
        int Remove(TEntity entity);
        int Update(TEntity entity);
    }
}
