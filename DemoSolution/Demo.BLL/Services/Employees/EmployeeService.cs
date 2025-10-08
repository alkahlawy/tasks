using AutoMapper;
using Demo.BLL.DTOs.Employees;
using Demo.DAL.Models.EmployeeModel;
using Demo.DAL.Repositories.Employees;

namespace Demo.BLL.Services.Employees
{
    public class EmployeeService(IEmployeeRepository _employeeRepository, IMapper _mapper) : IEmployeeService
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
            var employees = _employeeRepository.GetAll(withTracking);
            //                         From                    To
            return _mapper.Map<IEnumerable<Employee> , IEnumerable<EmployeeDto>>(employees);
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
