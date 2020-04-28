using CompanyService.Api.Queries.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.Domain
{
    public interface ICompanyService
    {
        Task<CompanyDto> FindCompanyByCode(int codeType, string code);
    }
}
