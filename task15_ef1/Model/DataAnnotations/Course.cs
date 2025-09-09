using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using task15_ef1.Model.ConventionBased;
using task15_ef1.Model.FluentAPI;

namespace task15_ef1.Model.DataAnnotations
{
    [Table("Course")]
    public class Course
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("Duration")]
        [StringLength(50)]
        public string Duration { get; set; }
        [Column("Name")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Column("Description")]
        [StringLength(500)]
        public string Description { get; set; }
        [Column("Top_ID")]
        public int TopId { get; set; }
        public Topic Topic { get; set; }
        public ICollection<StudCourse> StudCourses { get; set; }
        public ICollection<CourseInst> CourseInsts { get; set; }
    }
}
