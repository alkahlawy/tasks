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
            ITIDbContext context = new ITIDbContext(optionsBuilder.Options);
        }
    }
}
