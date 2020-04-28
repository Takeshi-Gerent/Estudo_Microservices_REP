using EmployeeService.DataAccess.EF.Configuration;
using EmployeeService.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.DataAccess.EF
{
    public class EmployeeDbContext: DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfig());


            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<Company>().HasMany(p => p.Employees).WithOne(p => p.Company);
            modelBuilder.Entity<Company>().HasKey("Id");
            
        }
    }
}
