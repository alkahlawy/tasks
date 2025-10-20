using Demo.DAL.Data.Contexts;
using Demo.DAL.Repositories.Departments;
using Demo.DAL.Repositories.Employees;
using Demo.DAL.Repositories.Shared.Interfaces;

namespace Demo.DAL.Repositories.Shared.Classes
{
    // CLR is responsible for creating Instances and Injecting Dependencies and control lifecycle
    // so if we need to do some action before destroying the instance we can implement IDisposable interface
    public class UnitOfWork : IUnitOfWork /*, IDisposable*/
    {
        // Lazy Injection to avoid circular dependency issues
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        private readonly Lazy<IDepartmentRepository> _departmentRepository;

        private readonly ApplicationDbContext _dbContext;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _employeeRepository = 
                new Lazy<IEmployeeRepository>(() => new EmployeeRepository(_dbContext));
            _departmentRepository = 
                new Lazy<IDepartmentRepository>(() => new DepartmentRepository(_dbContext));
        }
        public IEmployeeRepository EmployeeRepository => _employeeRepository.Value; // injected via constructor
        public IDepartmentRepository DepartmentRepository => _departmentRepository.Value;

        //public void Dispose()
        //{
        //    // some actions here
        //    _dbContext.Dispose();
        //}

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }   
    }
}
