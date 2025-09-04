using task15_ef1.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task15_ef1.Model.ConventionBased;
using task15_ef1.Model.FluentAPI;
using task15_ef1.Model.DataAnnotations;

namespace task15_ef1.Data
{
    public class ITIDbContext : DbContext
    {
        public ITIDbContext(DbContextOptions<ITIDbContext> options) : base(options)
        {
        }

        // Convention-based entities
        public DbSet<Student> Students { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<CourseInst> CourseInsts { get; set; }

        // Data Annotation entities
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }

        // Fluent API entities
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<StudCourse> StudCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply Fluent API configurations
            modelBuilder.ApplyConfiguration(new InstructorConfiguration());
            modelBuilder.ApplyConfiguration(new StudCourseConfiguration());

            // Additional Fluent API configurations for convention-based entities
            // if needed (overriding conventions)
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student"); // Override convention (singular instead of plural)
                entity.Property(e => e.DepId).HasColumnName("Dep_Id");
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=ITIDb;Trusted_Connection=True;");
            }
        }
    }
}
