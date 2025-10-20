using Demo.DAL.Data.Contexts;
using Demo.DAL.Models.DepartmentModel;
using Demo.DAL.Repositories.Departments;
using Demo.DAL.Repositories.Shared.Classes;
namespace Demo.DAL.Repositories
{
    public class DepartmentRepository(ApplicationDbContext _context) 
                    : GenericRepository<Department>(_context), IDepartmentRepository {}
}
