using task15_ef1.Data;
using Microsoft.EntityFrameworkCore;

namespace task15_ef1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ITIDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=ITIDb;Trusted_Connection=True;");
            using ITIDbContext context = new ITIDbContext(optionsBuilder.Options);

            #region DepartmentAndInstructor's data
            var deptInstructors = context.DepartmentAndInstructors.ToList();
            foreach (var di in deptInstructors)
            {
                Console.WriteLine($"Department ID: {di.DepartmentID}, Department Name: {di.DepartmentName}, Instructor Name: {di.InstructorName}");
            }
            #endregion



        }
    }
}
