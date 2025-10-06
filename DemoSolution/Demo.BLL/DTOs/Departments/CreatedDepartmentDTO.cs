using System.ComponentModel.DataAnnotations;

namespace Demo.BLL.DTOs.Departments
{
    public class CreatedDepartmentDTO
    {
        public string Code { get; set; }
        [MaxLength(10)]
        public string Name { get; set; }
        [Display(Name = "Creation Date")]
        public DateOnly CreatedAt { get; set; }
        public string? Description { get; set; }
    }
}
