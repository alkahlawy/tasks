using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task15_ef1.Model.ConventionBased;
using task15_ef1.Model.FluentAPI;
using task15_ef1.Model.DataAnnotations;
using task15_ef1.Data.Configurations;

namespace task15_ef1.Data
{
    public class ITIDbContext : DbContext
    {
        public ITIDbContext(DbContextOptions<ITIDbContext> options) : base(options) {}

        // Parameterless constructor for design-time migration support
        public ITIDbContext() : base(new DbContextOptionsBuilder<ITIDbContext>().UseSqlServer("Server=.;Database=ITIDb;Trusted_Connection=True;TrustServerCertificate=True;").Options) {}

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

            // Student - Department (many-to-one)
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.DepId);

            // Instructor - Department (many-to-one)
            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.Department)
                .WithMany(d => d.Instructors)
                .HasForeignKey(i => i.DeptId);

            // Course - Topic (many-to-one)
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Topic)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TopId);

            // StudCourse (many-to-one to Student and Course)
            modelBuilder.Entity<StudCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudCourses)
                .HasForeignKey(sc => sc.StudId);
            modelBuilder.Entity<StudCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudCourses)
                .HasForeignKey(sc => sc.CourseId);

            // CourseInst (many-to-one to Instructor and Course)
            modelBuilder.Entity<CourseInst>()
                .HasOne(ci => ci.Instructor)
                .WithMany(i => i.CourseInsts)
                .HasForeignKey(ci => ci.InstId);
            modelBuilder.Entity<CourseInst>()
                .HasOne(ci => ci.Course)
                .WithMany(c => c.CourseInsts)
                .HasForeignKey(ci => ci.CourseId);

            // Composite keys for StudCourse and CourseInst
            modelBuilder.Entity<StudCourse>()
                .HasKey(sc => new { sc.StudId, sc.CourseId });
            modelBuilder.Entity<CourseInst>()
                .HasKey(ci => new { ci.InstId, ci.CourseId });

            // Table name override for Student
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
                optionsBuilder.UseSqlServer("Server=.;Database=ITIDb;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}
