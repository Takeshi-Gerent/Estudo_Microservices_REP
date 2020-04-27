using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.Domain
{
    public class Employee
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Pis { get; private set; }
        public Company Company { get; private set; }

        private Employee()
        { }

        private Employee(string name, string pis, Company company)
        {
            Name = name;
            Pis = pis;
            Company = company;
        }

        public static Employee New(string name, string pis, Company company)
        {
            return new Employee(name, pis, company);
        }

    }
}
