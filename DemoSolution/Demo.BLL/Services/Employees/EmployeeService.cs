using AutoMapper;
using Demo.BLL.DTOs.Employees;
using Demo.BLL.Services.AttachmentService;
using Demo.DAL.Models.EmployeeModel;
using Demo.DAL.Repositories.Employees;
using Demo.DAL.Repositories.Shared.Interfaces;

namespace Demo.BLL.Services.Employees
{
    public class EmployeeService(IUnitOfWork _unitOfWork,
                                 IMapper _mapper,
                                 IAttachmentService _attachmentService
                                ) : IEmployeeService
    {
        public int AddEmployee(CreatedEmployeeDto createdEmployeeDto)
        {
            var employee = _mapper.Map<CreatedEmployeeDto, Employee>(createdEmployeeDto);
            if (createdEmployeeDto.Image != null)
            {
                employee.ImageName = _attachmentService.Upload(createdEmployeeDto.Image, "Images");
            }
            _unitOfWork.EmployeeRepository.Add(employee);
            return _unitOfWork.SaveChanges();
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetByID(id);
            if (employee is null) return false;
            else
            {
                employee.IsDeleted = true;
                _unitOfWork.EmployeeRepository.Update(employee);
                return _unitOfWork.SaveChanges() > 0; // Apply soft delete
            }
        }

        public IEnumerable<EmployeeDto> GetAll(string? EmployeeSearchName, bool withTracking = false)
        {
            //var employees = _employeeRepository.GetAll(
            //    withTracking: withTracking,
            //    predicate: e => string.IsNullOrEmpty(EmployeeSearchName) 
            //                    || e.Name!.ToLower().Contains(EmployeeSearchName.ToLower())
            //    );
            ////                         From                    To
            //return _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);

            //var employees = _employeeRepository.GetAll(
            //    withTracking: withTracking,
            //    selector: e => new EmployeeDto()
            //    {
            //        Id = e.Id,
            //        Name = e.Name,
            //        Age = e.Age,
            //        Salary = e.Salary,
            //        EmpType = e.EmployeeType.ToString(),
            //        Email = e.Email,
            //        IsActive = e.IsActive,
            //        EmpGender = e.Gender.ToString(),
            //        Department = e.Department != null ? e.Department.Name : null
            //    }); // second overload

            IEnumerable<Employee> employees;
            if (string.IsNullOrEmpty(EmployeeSearchName))
            {
                employees = _unitOfWork.EmployeeRepository.GetAll(withTracking: withTracking);
            }
            else
            {
                employees = _unitOfWork.EmployeeRepository.GetAll(
                    predicate: e => e.Name.ToLower().Contains(EmployeeSearchName.ToLower()),
                    withTracking: withTracking);
            }

            return _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);

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
            var employee = _unitOfWork.EmployeeRepository.GetByID(id);
            return employee is null ? null : _mapper.Map<Employee, EmployeeDetailsDto>(employee);
        }

        public int UpdateEmployee(UpdatedEmployeeDto updatedEmployeeDto)
        {
            var employee = _mapper.Map<UpdatedEmployeeDto, Employee>(updatedEmployeeDto);
            _unitOfWork.EmployeeRepository.Update(employee);
            return _unitOfWork.SaveChanges();
        }
    }
}
