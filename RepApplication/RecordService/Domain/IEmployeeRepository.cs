using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordService.Domain
{
    public interface IEmployeeRepository
    {
        Task<Employee> FindByPis(string pis);
    }
}
