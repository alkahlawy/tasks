using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
