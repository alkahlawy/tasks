using Demo.DAL.Data.Contexts;

namespace Demo.DAL.Repositories
{
    internal class DepartmentRepository(ApplicaionDbContext context) // High Level Module
    {
        private readonly ApplicaionDbContext _context = context;

        // CRUD Operations
        // Get Department By ID
        public Department? GetByID(int id)
        {
            var department = _context.Departments.Find(id);
            return department;
        }

        //public DepartmentRepository() 
        //{
        //    ApplicaionDbContext applicaionDbContext = new ApplicaionDbContext();
        //}
    }
}
