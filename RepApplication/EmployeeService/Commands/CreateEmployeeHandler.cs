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
        private readonly ICompanyRepository companyRepository;

        public CreateEmployeeHandler(IEmployeeRepository employeeRepository, ICompanyRepository companyRepository)
        {
            this.employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            this.companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));        }

        
        public async Task<CreateEmployeeResult> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var company = await companyRepository.FindByCode(
                (CompanyCodeType)Enum.Parse(typeof(CompanyCodeType), request.Employee.CompanyCodeType),
                request.Employee.CompanyCode);
            
            var employee = Employee.New(
                request.Employee.Name,
                request.Employee.Pis,
                company
                );            

            await employeeRepository.Add(employee);
            
            return new CreateEmployeeResult { EmployeeId = employee.Id };
        }
        
    }
}
