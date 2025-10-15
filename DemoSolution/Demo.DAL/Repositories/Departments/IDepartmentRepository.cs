using Demo.DAL.Models.DepartmentModel;
using Demo.DAL.Repositories.Shared;
namespace Demo.DAL.Repositories.Departments
{
    public interface IDepartmentRepository : IGeneticRepository<Department> {}
}