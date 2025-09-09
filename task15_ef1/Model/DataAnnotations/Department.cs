using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using task15_ef1.Model.ConventionBased;
using task15_ef1.Model.FluentAPI;

namespace task15_ef1.Model.DataAnnotations
{
    [Table("Department")]
    public class Department
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("Name")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Column("Ins_ID")]
        public int InsId { get; set; }
        [Column("HiringDate")]
        [DataType(DataType.Date)]
        public DateTime HiringDate { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Instructor> Instructors { get; set; }
    }
}
