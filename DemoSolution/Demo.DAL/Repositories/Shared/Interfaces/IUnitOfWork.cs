using Demo.DAL.Repositories.Departments;
using Demo.DAL.Repositories.Employees;

namespace Demo.DAL.Repositories.Shared.Interfaces
{
    public interface IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; }
        public IDepartmentRepository DepartmentRepository { get; }
        int SaveChanges();
    }
}
