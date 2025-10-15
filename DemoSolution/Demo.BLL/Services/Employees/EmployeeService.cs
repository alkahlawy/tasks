using AutoMapper;
using Demo.BLL.DTOs.Employees;
using Demo.DAL.Models.EmployeeModel;
using Demo.DAL.Repositories.Employees;

namespace Demo.BLL.Services.Employees
{
    public class EmployeeService(IEmployeeRepository _employeeRepository, IMapper _mapper)
        : IEmployeeService
    {
        public int AddEmployee(CreatedEmployeeDto createdEmployeeDto)
        {
            var employee = _mapper.Map<CreatedEmployeeDto, Employee>(createdEmployeeDto);
            return _employeeRepository.Add(employee);
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetByID(id);
            if (employee is null) return false;
            else
            {
                employee.IsDeleted = true;
                return _employeeRepository.Update(employee) > 0; // Apply soft delete
            }
        }

        public IEnumerable<EmployeeDto> GetAll(bool withTracking = false)
        {
            // var employees = _employeeRepository.GetAll(withTracking); first overload
            //                         From                    To
            // return _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);

            var employees = _employeeRepository.GetAll(
                withTracking: withTracking,
                selector: e => new EmployeeDto()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Age = e.Age,
                    Salary = e.Salary,
                    EmpType = e.EmployeeType.ToString(),
                    Email = e.Email,
                    IsActive = e.IsActive,
                    EmpGender = e.Gender.ToString(),
                    Department = e.Department != null ? e.Department.Name : null

                }); // second overload
            
            return employees;

            #region IEnumerable
            //var employees = _employeeRepository.GetIEnumerable()
            //                          .Where(e => e.IsDeleted == false)
            //                          .Select(e => new EmployeeDto()
            //                          {
            //                              Id = e.Id,
            //                              Name = e.Name,
            //                              Age = e.Age,
            //                              Salary = e.Salary,
            //                          });
            //// The above LINQ will be converted by EF Core to the following SQL:
            //// SELECT * FROM[Employees] AS[e]
            //// and then the projection will be done in memory 
            #endregion

            #region IQueryable
            //var employees = _employeeRepository.GetIQueryable()
            //                          .Where(e => e.IsDeleted == false)
            //                          .Select(e => new EmployeeDto()
            //                          {
            //                              Id = e.Id,
            //                              Name = e.Name,
            //                              Age = e.Age,
            //                              Salary = e.Salary,
            //                          });
            // The above LINQ will be converted by EF Core to the following SQL:
            // SELECT [e].[Id], [e].[Name], [e].[Age], [e].[Salary]
            // FROM [Employees] AS [e]
            // WHERE [e].[IsDeleted] = CAST(0 AS bit)
            // and then the projection will be done in the database server 
            #endregion

        }

        public EmployeeDetailsDto? GetById(int id)
        {
            var employee = _employeeRepository.GetByID(id);
            return employee is null ? null : _mapper.Map<Employee, EmployeeDetailsDto>(employee);
        }

        public int UpdateEmployee(UpdatedEmployeeDto updatedEmployeeDto)
        {
            var employee = _mapper.Map<UpdatedEmployeeDto, Employee>(updatedEmployeeDto);
            return _employeeRepository.Update(employee);
        }
    }
}
