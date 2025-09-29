using Demo.DAL.Data.Configrations;

namespace Demo.DAL.Data.Contexts
{
    
    public class ApplicaionDbContext(DbContextOptions<ApplicaionDbContext> options) : DbContext(options)
    {
        public DbSet<Department> Departments { get; set; }
        //override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=DemoDB;Trusted_Connection=True;TrustServerCertificate=True;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DepartmentConfigurations).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
