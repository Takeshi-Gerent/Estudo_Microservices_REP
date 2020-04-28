using System;
using System.Collections.Generic;
using System.Text;
using CompanyService.Api.Queries.Dtos;
using MediatR;

namespace CompanyService.Api.Queries
{
    public class FindCompanyByCodeQuery: IRequest<CompanyDto>
    {
        public CompanyCodeType CodeType { get; set; }
        public string Code { get; set; }
    }

    public enum CompanyCodeType
    {
        CNPJ,
        CEI
    }
}
