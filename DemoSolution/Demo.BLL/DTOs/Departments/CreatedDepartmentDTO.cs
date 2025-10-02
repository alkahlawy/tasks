using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.DTOs.Departments
{
    public class CreatedDepartmentDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public DateOnly CreatedAt { get; set; }
        public string? Description { get; set; }
    }
}
