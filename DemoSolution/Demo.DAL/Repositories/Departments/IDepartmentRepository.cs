using Demo.DAL.Models;
namespace Demo.DAL.Repositories.Departments
{
    public interface IDepartmentRepository
    {
        int Add(Department department);
        IEnumerable<Department> GetAll(bool withTracking = false);
        Department? GetByID(int id);
        int Remove(Department department);
        int Update(Department department);
    }
}