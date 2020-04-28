using CompanyService.Api.Queries.Dtos;
using EmployeeService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.RestClients
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyClient companyClient;

        public CompanyService(ICompanyClient companyClient)
        {
            this.companyClient = companyClient;
        }

        public async Task<CompanyDto> FindCompanyByCode(int codeType, string code)
        {
            return await companyClient.FindCompanyByCode(codeType, code);            
        }
    }
}
