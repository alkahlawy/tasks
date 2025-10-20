using Demo.DAL.Models.EmployeeModel;
using Demo.DAL.Repositories.Shared.Interfaces;

namespace Demo.DAL.Repositories.Employees
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
    }
}
