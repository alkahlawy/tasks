using Demo.BLL.DTOs.Departments;
using Demo.BLL.Factories;
using Demo.DAL.Repositories.Shared.Interfaces;
namespace Demo.BLL.Services.Departments
{
    public class DepartmentServices(IUnitOfWork _unitOfWork)
                                   : IDepartmentServices
    {
        // Primary Constructor Injection
        //private readonly IDepartmentRepository _departmentRepository = departmentRepository;


        // Mapping
        // 1) Manual Mapping
        // 2) AutoMapper (NuGet Package)
        // 3) Constructor Mapping
        // 4) Extension Method Mapping

        // Get All

        public IEnumerable<DepartmentDTO> GetAll(bool withTracking = false)
        {
            // Extension Method Mapping
            var depts = _unitOfWork.DepartmentRepository.GetAll(withTracking);
            var departmentToReturn = depts.Select(d => d.ToDepartmentDTO());
            return departmentToReturn;

        }

        public DepartmentDetailsDTO? GetById(int id)
        {
            #region Manual Mapping
            // Manual Mapping
            //var departments = _departmentRepository.GetByID(id);
            //if (departments is null) return null;
            //else
            //    return new DepartmentDetailsDTO
            //    {
            //        Id = departments.Id,
            //        Name = departments.Name,
            //        Code = departments.Code,
            //        Description = departments.Description,
            //        DateOfCreation = DateOnly.FromDateTime(departments.CreatedOn),
            //        LastModifiedBy = departments.LastModifiedBy,
            //        LastModifiedOn = DateOnly.FromDateTime(departments.LastModifiedOn),
            //        CreatedBy = departments.CreatedBy,
            //        IsDeleted = departments.IsDeleted
            //    }; 
            #endregion

            // Constructor Mapping
            var department = _unitOfWork.DepartmentRepository.GetByID(id);
            return department is null ? null : department.ToDepartmentDetailsDTO();
        }

        public int AddDepartment(CreatedDepartmentDTO createdDepartmentDTO)
        {
            var departmentEntity = createdDepartmentDTO.ToDepartmentEntity();
            _unitOfWork.DepartmentRepository.Add(departmentEntity);
            return _unitOfWork.SaveChanges();
        }

        public int UpdateDepartment(UpdatedDepartmentDTO updatedDepartmentDTO)
        {
            var departmentEntity = updatedDepartmentDTO.ToDepartmentEntity();
            _unitOfWork.DepartmentRepository.Update(departmentEntity);
            return _unitOfWork.SaveChanges();
        }

        public bool DeleteDepartment(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetByID(id);
            if (department is null) return false;
            else
            {
                _unitOfWork.DepartmentRepository.Remove(department);
                var res = _unitOfWork.SaveChanges();
                return res > 0; // return true if one or more rows affected else false
            }
        }
    }
}
