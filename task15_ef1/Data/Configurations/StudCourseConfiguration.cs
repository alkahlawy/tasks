using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task15_ef1.Model.FluentAPI;

namespace task15_ef1.Data.Configurations
{
    public class StudCourseConfiguration : IEntityTypeConfiguration<StudCourse>
    {
        public void Configure(EntityTypeBuilder<StudCourse> builder)
        {
            // Table mapping
            builder.ToTable("Stud_Course");

            // Composite primary key
            builder.HasKey(sc => new { sc.StudId, sc.CourseId });

            // Property configurations
            builder.Property(sc => sc.StudId)
                .HasColumnName("stud_ID");

            builder.Property(sc => sc.CourseId)
                .HasColumnName("Course_ID");

            builder.Property(sc => sc.Grade)
                .HasColumnName("Grade")
                .HasColumnType("decimal(5,2)");
        }
    }
}
