using Demo.DAL.Data.Configrations;
using Demo.DAL.Data.Configurations;
using Demo.DAL.Models.DepartmentModel;
using Demo.DAL.Models.EmployeeModel;

namespace Demo.DAL.Data.Contexts
{
    
    public class ApplicaionDbContext(DbContextOptions<ApplicaionDbContext> options) : DbContext(options)
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        //override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=DemoDB;Trusted_Connection=True;TrustServerCertificate=True;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DepartmentConfigurations).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeConfigurations).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
