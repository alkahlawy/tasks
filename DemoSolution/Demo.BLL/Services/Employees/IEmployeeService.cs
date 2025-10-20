using Demo.BLL.DTOs.Departments;
using Demo.BLL.DTOs.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Services.Employees
{
    public interface IEmployeeService
    {
        int AddEmployee(CreatedEmployeeDto createdEmployeeDto);
        bool DeleteEmployee(int id);
        IEnumerable<EmployeeDto> GetAll(string? EmployeeSearchName, bool withTracking = false);
        EmployeeDetailsDto? GetById(int id);
        int UpdateEmployee(UpdatedEmployeeDto updatedEmployeeDto);
    }
}
