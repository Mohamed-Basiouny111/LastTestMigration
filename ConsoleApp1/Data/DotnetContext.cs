using ConsoleApp1.Configuration;
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Data
{
    public class DotnetContext : DbContext
    {
        //public DbSet<Person> people { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Befor Lazy Loading
            //optionsBuilder.UseSqlServer("Data Source =.;Initial Catalog=Dotnet2;Integrated Security=True;Trust Server Certificate=True;");
            //base.OnConfiguring(optionsBuilder);

            //After Lazy Loading
            //Don't Load Data if don't use , when use or call loading it 
            //optionsBuilder.UseLazyLoadingProxies()
            //    .UseSqlServer("Data Source =.;Initial Catalog=Dotnet2;Integrated Security=True;Trust Server Certificate=True;");

            //After Notraking in all database(Make Read only)
            optionsBuilder.UseLazyLoadingProxies()
                .UseSqlServer("Data Source =.;Initial Catalog=Dotnet2;Integrated Security=True;Trust Server Certificate=True;")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Person>(p =>
            //{
            //    p.UseTphMappingStrategy();
            //    //p.UseTptMappingStrategy();
            //    //p.UseTpcMappingStrategy(); //should convert person to abstract
            //});

            #region Before use External Configuration
            //modelBuilder.Entity<Student>(c =>
            //{
            //    c.Property(c => c.StdName).HasMaxLength(50);
            //});
            //modelBuilder.Entity<Employee>(c =>
            //{
            //    c.Property(c => c.Salary).IsRequired(true);
            //});
            //modelBuilder.Entity<Department>(c =>
            //{
            //    c.Property(c => c.DeptName).IsRequired(true).HasMaxLength(100);
            //}); 
            #endregion

            #region use External Configuration

            //Apply Configuration to type alone 
            //modelBuilder.ApplyConfiguration<Student>(new StudentConfiguration());
            //modelBuilder.ApplyConfiguration<Employee>(new EmployeeConfiguration());
            //modelBuilder.ApplyConfiguration<Department>(new DepartmentConfiguration());

            ////Apply Configuration to all type in Assembly
            //typeof(Student).Assembly => return assemply name , can use any type like student or any type in assemply 
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(Student).Assembly);
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
