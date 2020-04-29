using EmployeeService.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EmployeeService.Test.Domain
{
    public class EmployeeTest
    {
        [Fact]
        public void New()
        {
            var employee = Employee.New("Fulano da Silva", "12134112", Company.ForEmployee(1, CompanyCodeType.CNPJ, "111111"));

            Assert.Equal("Fulano da Silva", employee.Name);
            Assert.Equal("12134112", employee.Pis);                        
        }
    }
}
