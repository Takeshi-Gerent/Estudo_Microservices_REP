using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.Domain
{
    public interface IEmployeeRepository
    {
        Task<Employee> Add(Employee employee);
        Task<Employee> FindByPis(string pis);
    }
}
