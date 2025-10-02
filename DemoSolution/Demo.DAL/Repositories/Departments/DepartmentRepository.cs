using Demo.DAL.Data.Contexts;
using Demo.DAL.Repositories.Departments;
namespace Demo.DAL.Repositories
{
    public class DepartmentRepository(ApplicaionDbContext _context) : IDepartmentRepository
    // High Level Module
    {
        //private readonly ApplicaionDbContext _context = context; // Low Level Module

        // CRUD Operations
        // Get Department By ID
        public Department? GetByID(int id)
        {
            var department = _context.Departments.Find(id);
            return department;
        }

        // Get All Departments
        public IEnumerable<Department> GetAll(bool withTracking = false)
        {
            if (withTracking) return _context.Departments.ToList();
            else return _context.Departments.AsNoTracking().ToList(); // Best for ReadOnly Operations and Performance
        }

        // Add Department
        public int Add(Department department)
        {
            _context.Departments.Add(department);
            return _context.SaveChanges(); // SaveChanges returns number of affected rows
        }

        // Update Department
        public int Update(Department department)
        {
            _context.Departments.Update(department);
            return _context.SaveChanges();
        }

        public int Remove(Department department)
        {
            _context.Departments.Remove(department);
            return _context.SaveChanges();
        }

        //public DepartmentRepository() 
        //{
        //    ApplicaionDbContext applicaionDbContext = new ApplicaionDbContext();
        //}
    }
}
