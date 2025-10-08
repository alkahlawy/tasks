using Demo.DAL.Models.EmployeeModel;
using Demo.DAL.Models.Shared.Enums;

namespace Demo.DAL.Data.Configurations
{
    internal class EmployeeConfigurations : BaseConfigurations<Employee>,IEntityTypeConfiguration<Employee>
    {
        public new void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasColumnType("nvarchar(50)");
            builder.Property(e => e.Address)
                    .HasColumnType("nvarchar(150)");
            builder.Property(e => e.Salary)
                   .HasColumnType("decimal(10,2)"); 
            builder.Property(e => e.Gender)
                   .HasConversion(
                    (empGender) => empGender.ToString(), // to store as string in database
                    (gender) => (Gender) Enum.Parse(typeof(Gender), gender) // to convert back to enum when retrieving from database
                    );
            builder.Property(e => e.EmployeeType)
                   .HasConversion(
                    (empType) => empType.ToString(),
                    (type) => (EmployeeType)Enum.Parse(typeof(EmployeeType), type)
                    );

            base.Configure(builder); // to apply base configurations
        }
    }
}
