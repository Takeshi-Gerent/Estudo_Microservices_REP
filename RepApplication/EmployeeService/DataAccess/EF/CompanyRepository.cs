using EmployeeService.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.DataAccess.EF
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly EmployeeDbContext employeeDbContext;

        public CompanyRepository(EmployeeDbContext employeeDbContext)
        {
            this.employeeDbContext = employeeDbContext ?? throw new ArgumentNullException(nameof(employeeDbContext));
        }

        public async Task<Company> FindByCode(CompanyCodeType codeType, string code)
        {
            return await employeeDbContext.Companies.FirstOrDefaultAsync(p => p.CodeType == codeType && p.Code == code);
        }
    }
}
