using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.Domain
{
    public class Company
    {
        public int Id { get; private set; }
        public CompanyCodeType CodeType { get; private set; }
        public string Code { get; private set; }

        public IList<Employee> Employees { get; private set; }

        public Company(int id,CompanyCodeType codeType, string code)
        {
            Id = id;
            CodeType = codeType;
            Code = code;
        }
    }

    public enum CompanyCodeType
    {
        CNPJ,
        CEI
    }
}
