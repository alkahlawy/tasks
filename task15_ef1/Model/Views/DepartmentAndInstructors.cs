using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task15_ef1.Model.ConventionBased;
using task15_ef1.Model.DataAnnotations;

namespace task15_ef1.Model.Views
{
    public class DepartmentAndInstructors
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string? InstructorName { get; set; }
    }
}
