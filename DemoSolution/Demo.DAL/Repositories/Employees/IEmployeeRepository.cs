using Demo.DAL.Models.EmployeeModel;
using Demo.DAL.Repositories.Shared;

namespace Demo.DAL.Repositories.Employees
{
    public interface IEmployeeRepository : IGeneticRepository<Employee>
    {
    }
}
