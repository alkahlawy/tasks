using Demo.DAL.Data.Configurations;
using Demo.DAL.Models.DepartmentModel;

namespace Demo.DAL.Data.Configrations
{
    public class DepartmentConfigurations : BaseConfigurations<Department>, IEntityTypeConfiguration<Department>
    {
        public new void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Id).UseIdentityColumn(10,10);
            builder.Property(d => d.Name).HasColumnType("varchar(20)");
            builder.Property(d => d.Code).HasColumnType("varchar(20)");
            builder.Property(d => d.Description).HasColumnType("varchar(200)");

            builder.HasMany(d => d.Employees)
                   .WithOne(emp => emp.Department)
                   .HasForeignKey(emp => emp.DepartmentId)
                   .OnDelete(DeleteBehavior.SetNull);

            base.Configure(builder); // to apply base configurations
        }
    }
}
