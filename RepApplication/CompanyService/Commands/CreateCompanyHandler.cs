using CompanyService.Api.Commands;
using CompanyService.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CompanyService.Commands
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, CreateCompanyResult>
    {
        private readonly IUnitOfWork uow;

        public CreateCompanyHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<CreateCompanyResult> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = Company.New(request.Name, (Domain.CompanyCodeType)request.CodeType, request.Code, request.Address);

            uow.CompanyRepository.Add(company);
            await uow.CommitChanges();

            return new CreateCompanyResult { Id = company.Id.GetValueOrDefault(), Name = company.Name };
        }
    }
}
