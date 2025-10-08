using Demo.DAL.Data.Contexts;
using Demo.DAL.Models.EmployeeModel;
using Demo.DAL.Repositories.Shared;

namespace Demo.DAL.Repositories.Employees
{
    public class EmployeeRepository(ApplicaionDbContext _context) // pass the context to the base class 
                    : GeneticRepository<Employee>(_context), IEmployeeRepository
    {
        
    }
}
