using Demo.DAL.Models.Shared;
using Demo.DAL.Models.Shared.Enums;

namespace Demo.DAL.Models.EmployeeModel
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; } = null;
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int Age { get; set; }
        public Gender Gender {get; set; }
        public EmployeeType EmployeeType { get; set; }
        public bool IsActive { get; set; }
        public decimal Salary { get; set; }
        public DateTime HiringDate { get; set; }
    }
}
