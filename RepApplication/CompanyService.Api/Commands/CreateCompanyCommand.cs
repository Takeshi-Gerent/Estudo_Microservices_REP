using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyService.Api.Commands
{
    public class CreateCompanyCommand: IRequest<CreateCompanyResult>
    {        
        public string Name { get; set; }
        public CompanyCodeType CodeType { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
    }

    public enum CompanyCodeType
    {
        CNPJ,
        CEI
    }
}
