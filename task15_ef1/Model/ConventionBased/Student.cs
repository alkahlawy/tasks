using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using task15_ef1.Model.DataAnnotations;
using task15_ef1.Model.FluentAPI;

namespace task15_ef1.Model.ConventionBased
{
    public class Student
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public int DepId { get; set; }
        public Department Department { get; set; }
        public ICollection<StudCourse> StudCourses { get; set; }
    }
}
