using Demo.DAL.Models;

namespace Demo.BLL.DTOs.Departments
{
    public class DepartmentDTO
    {

        //public DepartmentDTO(Department department)
        //{
        //    DeptId = department.Id;
        //    DeptName = department.Name;
        //    DeptCode = department.Code;
        //    DeptDescription = department.Description;
        //    DateOfCreation = DateOnly.FromDateTime(department.CreatedOn);
        //}

        public int DeptId { get; set; }
        public string DeptName { get; set; } = null!;
        public string DeptCode { get; set; } = null!;
        public string? DeptDescription { get; set; }
        public DateOnly DateOfCreation { get; set; }

    }
}
