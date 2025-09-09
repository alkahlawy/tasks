using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task15_ef1.Model.ConventionBased;
using task15_ef1.Model.DataAnnotations;

namespace task15_ef1.Model.FluentAPI
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Bonus { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public int HourRate { get; set; }
        public int DeptId { get; set; }
        public Department Department { get; set; }
        public ICollection<CourseInst> CourseInsts { get; set; }
    }
}
