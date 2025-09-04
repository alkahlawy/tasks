using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task15_ef1.Model.ConventionBased;

namespace task15_ef1.Data.Configurations
{
    public class CourseInstConfiguration : IEntityTypeConfiguration<CourseInst>
    {
        public void Configure(EntityTypeBuilder<CourseInst> builder)
        {
            // Table mapping
            builder.ToTable("Course_Inst");

            // Composite primary key
            builder.HasKey(ci => new { ci.InstId, ci.CourseId });

            // Additional property configuration
            builder.Property(ci => ci.Evaluate)
                .HasColumnName("evaluate")
                .HasMaxLength(200);
        }
    }
}
