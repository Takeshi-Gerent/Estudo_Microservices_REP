using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EmployeeService.Api.Commands;
using EmployeeService.Domain;
using MediatR;

namespace EmployeeService.Commands
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, CreateEmployeeResult>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly ICompanyService companyService;

        public CreateEmployeeHandler(IEmployeeRepository employeeRepository, ICompanyService companyService)
        {
            this.employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            this.companyService = companyService;
        }

        
        public async Task<CreateEmployeeResult> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var company = await companyService.FindCompanyByCode(request.Employee.CompanyCodeType, request.Employee.CompanyCode);
            var employee = Employee.New(
                request.Employee.Name,
                request.Employee.Pis,
                Company.FromId(company.Id)
                );

            await employeeRepository.Add(employee);
            
            return new CreateEmployeeResult { EmployeeId = employee.Id };
        }
        
    }
}
