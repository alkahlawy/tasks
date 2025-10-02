using Demo.BLL.DTOs.Departments;

namespace Demo.BLL.Services.Departments
{
    public interface IDepartmentServices
    {
        int AddDepartment(CreatedDepartmentDTO createdDepartmentDTO);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentDTO> GetAll(bool withTracking = false);
        DepartmentDetailsDTO? GetById(int id);
        int UpdateDepartment(UpdatedDepartmentDTO updatedDepartmentDTO);
    }
}