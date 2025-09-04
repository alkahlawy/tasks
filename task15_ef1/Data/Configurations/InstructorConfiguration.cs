using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using task15_ef1.Model.FluentAPI;

namespace task15_ef1.Data.Configurations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            // Table mapping
            builder.ToTable("Instructor");

            // Primary key
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).HasColumnName("ID");

            // Property configurations
            builder.Property(i => i.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(i => i.Bonus)
                .HasColumnName("Bonus")
                .HasColumnType("decimal(10,2)");

            builder.Property(i => i.Salary)
                .HasColumnName("Salary")
                .HasColumnType("decimal(10,2)");

            builder.Property(i => i.Address)
                .HasColumnName("Address")
                .HasMaxLength(200);

            builder.Property(i => i.HourRate)
                .HasColumnName("HourRate");

            builder.Property(i => i.DeptId)
                .HasColumnName("Dept_ID");
        }
    }
}
