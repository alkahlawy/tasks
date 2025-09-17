using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingInheritance.Data.Models
{
    internal class PartTimeEmployee : Employee
    {
        public decimal HourlyRate { get; set; }
        public int CountOfHours { get; set; }
    }
}
