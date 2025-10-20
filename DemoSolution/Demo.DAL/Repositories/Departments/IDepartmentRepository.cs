using Demo.DAL.Models.DepartmentModel;
using Demo.DAL.Repositories.Shared.Interfaces;
namespace Demo.DAL.Repositories.Departments
{
    public interface IDepartmentRepository : IGenericRepository<Department> {}
}