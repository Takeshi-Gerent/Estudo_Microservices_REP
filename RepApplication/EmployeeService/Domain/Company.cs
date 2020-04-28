using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.Domain
{
    public class Company
    {
        public int Id { get; private set; }

        public IList<Employee> Employees { get; private set; }

        private Company(int id)
        {
            Id = id;
        }

        public static Company FromId(int id)
        {
            return new Company(id);
        }
    }

}
