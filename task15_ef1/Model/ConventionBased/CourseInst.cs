using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task15_ef1.Model.DataAnnotations;
using task15_ef1.Model.FluentAPI;

namespace task15_ef1.Model.ConventionBased
{
    public class CourseInst
    {
        public int InstId { get; set; }
        public int CourseId { get; set; }
        public string Evaluate { get; set; }
        public Instructor Instructor { get; set; }
        public Course Course { get; set; }
    }
}
