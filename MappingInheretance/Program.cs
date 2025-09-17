using MappingInheritance.Data;
using MappingInheritance.Data.Models;

namespace MappingInheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using MyCompanyDbContext myCompanyContext = new MyCompanyDbContext();
            #region TPC Impl
            // Add Employees
            //var emp1 = new FullTimeEmployee
            //{
            //    Name = "Alice Johnson",
            //    Address = "123 Main St",
            //    Age = 30,
            //    Salary = 60000,
            //    StartDate = new DateTime(2022, 1, 15)
            //};
            //var emp2 = new PartTimeEmployee
            //{
            //    Name = "Bob Smith",
            //    Address = "456 Oak Ave",
            //    Age = 22,
            //    HourlyRate = 20,
            //    CountOfHours = 120
            //};
            //myCompanyContext.FullTimeEmployees.Add(emp1);
            //myCompanyContext.PartTimeEmployees.Add(emp2);
            #endregion

            #region TPH Impl
            //var emp3 = new FullTimeEmployee
            //{
            //    Name = "Alice Johnson",
            //    Address = "123 Main St",
            //    Age = 30,
            //    Salary = 60000,
            //    StartDate = new DateTime(2022, 1, 15)
            //};
            //var emp4 = new PartTimeEmployee
            //{
            //    Name = "Bob Smith",
            //    Address = "456 Oak Ave",
            //    Age = 22,
            //    HourlyRate = 20,
            //    CountOfHours = 120
            //};
            //myCompanyContext.Employees.Add(emp3);
            //myCompanyContext.Employees.Add(emp4);
            #endregion


            myCompanyContext.SaveChanges();
        }
    }
}
