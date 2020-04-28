using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CompanyService.Api.Queries;
using CompanyService.Api.Queries.Dtos;
using CompanyService.Domain;
using MediatR;

namespace CompanyService.Queries
{
    public class FindCompanyByCodeHandler : IRequestHandler<FindCompanyByCodeQuery, CompanyDto>
    {
        private readonly IUnitOfWork uow;

        public FindCompanyByCodeHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<CompanyDto> Handle(FindCompanyByCodeQuery request, CancellationToken cancellationToken)
        {
            var company = await uow.CompanyRepository.WithCode((Domain.CompanyCodeType)request.CodeType, request.Code);
            if (company == null)
            {
                throw new ApplicationException(string.Format("Empresa não cadastrada: {0} - {1}",
                    request.CodeType == Api.Queries.CompanyCodeType.CNPJ ? "CPNJ" : "CEI",
                    request.Code));
            }

            return ConstructResult(company);
        }

        private CompanyDto ConstructResult(Company company)
        {
            return new CompanyDto
            {
                Id = company.Id.GetValueOrDefault()
            };
        }
    }
}
