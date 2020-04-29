using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.Domain
{
    public interface ICompanyRepository
    {
        Task<Company> FindByCode(CompanyCodeType codeType, string Code);
    }
}
