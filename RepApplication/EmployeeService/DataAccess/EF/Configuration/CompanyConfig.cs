using EmployeeService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.DataAccess.EF.Configuration
{
    internal class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> entity)
        {
            entity.ToTable("Company");

            entity.HasKey("Id");
            entity.Property(q => q.CodeType);
            entity.Property(q => q.Code);

            entity.HasMany(p => p.Employees).WithOne(p => p.Company);

        }
    }
}
