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

        private Employee(string name, string pis)
        {
            Name = name;
            Pis = pis;
        }

        public static Employee New(string name, string pis, Company company)
        {
            var employee = new Employee(name, pis);
            employee.SetCompany(company);
            return employee;
        }

        private void SetCompany(Company company)
        {
            if (company == null)
            {
                throw new ArgumentException("Compania não pode ser nula.");
            }
            Company = company;
        }

    }
}
