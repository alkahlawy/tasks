using Demo.DAL.Data.Contexts;
using Demo.DAL.Models.EmployeeModel;
using Demo.DAL.Repositories.Shared.Classes;

namespace Demo.DAL.Repositories.Employees
{
    public class EmployeeRepository(ApplicationDbContext _context) // pass the context to the base class 
                    : GenericRepository<Employee>(_context), IEmployeeRepository
    {
        
    }
}
