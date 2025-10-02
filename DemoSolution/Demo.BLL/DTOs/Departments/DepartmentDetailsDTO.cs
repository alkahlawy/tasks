using Demo.DAL.Models;

namespace Demo.BLL.DTOs.Departments
{
    public class DepartmentDetailsDTO
    {

        //public DepartmentDetailsDTO(Department department)
        //{ // Set Values from Department Entity to DepartmentDetailsDTO
        //  // Constructor Mapping
        //    Id = department.Id;
        //    Name = department.Name;
        //    Code = department.Code;
        //    Description = department.Description;
        //    DateOfCreation = DateOnly.FromDateTime(department.CreatedOn);
        //    LastModifiedBy = department.LastModifiedBy;
        //    LastModifiedOn = DateOnly.FromDateTime(department.LastModifiedOn);
        //    CreatedBy = department.CreatedBy;
        //    IsDeleted = department.IsDeleted;
        //}

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        public DateOnly DateOfCreation { get; set; }
        public int LastModifiedBy { get; set; }
        public DateOnly LastModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
