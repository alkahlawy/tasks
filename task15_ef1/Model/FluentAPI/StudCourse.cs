using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task15_ef1.Model.ConventionBased;
using task15_ef1.Model.DataAnnotations;

namespace task15_ef1.Model.FluentAPI
{
    public class StudCourse
    {
        public int StudId { get; set; }
        public int CourseId { get; set; }
        public decimal Grade { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
