using MappingInheritance.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingInheritance.Data
{
    internal class MyCompanyDbContext : DbContext
    {
        public MyCompanyDbContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=MyCompanyDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region TPH

            //modelBuilder.Entity<FullTimeEmployee>()
            //    .HasBaseType(typeof(Employee));
            //modelBuilder.Entity<PartTimeEmployee>()
            //    .HasBaseType(typeof(Employee));

            //modelBuilder.Entity<Employee>()
            //    .HasDiscriminator<string>("EmpType")
            //    .HasValue<FullTimeEmployee>("FTE")
            //    .HasValue<PartTimeEmployee>("PTE");

            #endregion

            #region TPT
            modelBuilder.Entity<FullTimeEmployee>()
                .ToTable("FullTimeEmployees")
                .HasBaseType(typeof(Employee));
            modelBuilder.Entity<PartTimeEmployee>()
                .ToTable("PartTimeEmployees")
                .HasBaseType(typeof(Employee));
            #endregion
        }

        #region TPCT
        //public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }
        //public DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }
        #endregion

        #region TPHT
        //public DbSet<Employee> Employees { get; set; }
        //public DbSet<FullTimeEmployee> FullTimerEmployees { get; set; }
        //public DbSet<PartTimeEmployee> PartTimerEmployees { get; set; }
        #endregion

        #region TPT
        public DbSet<Employee> Employees { get; set; }
        public DbSet<FullTimeEmployee> FullTimerEmployees { get; set; }
        public DbSet<PartTimeEmployee> PartTimerEmployees { get; set; }
        #endregion
    }
}
