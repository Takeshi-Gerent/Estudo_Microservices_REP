using EmployeeService.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.DataAccess.EF
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext employeeDbContext;

        public EmployeeRepository(EmployeeDbContext employeeDbContext)
        {
            this.employeeDbContext = employeeDbContext ?? throw new ArgumentNullException(nameof(employeeDbContext));
        }

        public async Task<Employee> Add(Employee employee)
        {            
            await employeeDbContext.Employees.AddAsync(employee);
            await employeeDbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> FindByPis(string pis)
        {
            return await employeeDbContext.Employees.FirstOrDefaultAsync(p => p.Pis == pis);            
        }
    }
}
