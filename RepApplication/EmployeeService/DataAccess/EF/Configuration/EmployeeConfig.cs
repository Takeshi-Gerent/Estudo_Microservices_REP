using EmployeeService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.DataAccess.EF.Configuration
{
    internal class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> entity)
        {
            entity.ToTable("Employee");
            entity.Property(q => q.Name).IsRequired();
            entity.Property(q => q.Pis).IsRequired();
            entity.HasOne(q => q.Company).WithMany(q => q.Employees).HasForeignKey("CompanyId");
        }
    }
}
