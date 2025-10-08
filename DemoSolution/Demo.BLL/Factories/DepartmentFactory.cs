using Demo.BLL.DTOs.Departments;
using Demo.DAL.Models.DepartmentModel;

namespace Demo.BLL.Factories
{
    static class DepartmentFactory
    {
        // Exstension method to convert Department to DepartmentDTO
        public static DepartmentDTO ToDepartmentDTO(this Department department)
        {
            return new DepartmentDTO()
            {
                DeptId = department.Id,
                DeptName = department.Name,
                DeptCode = department.Code,
                DeptDescription = department.Description,
                DateOfCreation = DateOnly.FromDateTime(department.CreatedOn)
            };
        }

        public static DepartmentDetailsDTO ToDepartmentDetailsDTO(this Department department)
        {
            return new DepartmentDetailsDTO()
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                DateOfCreation = DateOnly.FromDateTime(department.CreatedOn),
                LastModifiedBy = department.LastModifiedBy,
                LastModifiedOn = DateOnly.FromDateTime(department.LastModifiedOn),
                CreatedBy = department.CreatedBy,
                IsDeleted = department.IsDeleted
            };
        }

        public static Department ToDepartmentEntity(this CreatedDepartmentDTO createdDepartmentDTO)
        {
            return new Department()
            {
                
                Name = createdDepartmentDTO.Name,
                Code = createdDepartmentDTO.Code,
                Description = createdDepartmentDTO.Description,
                CreatedOn = createdDepartmentDTO.CreatedAt.ToDateTime(new TimeOnly(0, 0)),
            };
        }

        public static Department ToDepartmentEntity(this UpdatedDepartmentDTO updatedDepartmentDTO)
        {
            return new Department()
            {

                Id = updatedDepartmentDTO.Id,
                Name = updatedDepartmentDTO.Name,
                Code = updatedDepartmentDTO.Code,
                Description = updatedDepartmentDTO.Description,
                CreatedOn = updatedDepartmentDTO.CreatedAt.ToDateTime(new TimeOnly(0, 0)),
            };
        }
    }
}
