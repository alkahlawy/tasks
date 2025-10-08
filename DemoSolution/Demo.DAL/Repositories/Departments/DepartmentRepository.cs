using Demo.DAL.Data.Contexts;
using Demo.DAL.Models.DepartmentModel;
using Demo.DAL.Repositories.Departments;
using Demo.DAL.Repositories.Shared;
namespace Demo.DAL.Repositories
{
    public class DepartmentRepository(ApplicaionDbContext _context) 
                    : GeneticRepository<Department>(_context), IDepartmentRepository
    {
    }
}
