using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.Domain
{
    public enum CompanyCodeType
    {
        CNPJ,
        CEI
    }

    public class Company
    {
        public int Id { get; private set; }
        public CompanyCodeType CodeType { get; private set; }
        public string Code { get; private set; }


        public IList<Employee> Employees { get; private set; }

        private Company(int id, CompanyCodeType codeType, string code)
        {
            Id = id;
            CodeType = codeType;
            Code = code;
        }

        public static Company ForEmployee(int id, CompanyCodeType codeType, string code)
        {
            return new Company(id,codeType, code);
        }
    }

}
