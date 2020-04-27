using EmployeeService.Api.Queries;
using EmployeeService.Api.Queries.Dtos;
using EmployeeService.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Queries
{
    public class FindEmployeeByPisHandler : IRequestHandler<FindEmployeeByPisQuery, EmployeeDto>
    {
        private readonly IEmployeeRepository employeeRepository;

        public FindEmployeeByPisHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public async Task<EmployeeDto> Handle(FindEmployeeByPisQuery request, CancellationToken cancellationToken)
        {
            var result = await employeeRepository.FindByPis(request.Pis);

            return result != null ? new EmployeeDto
            {
                Id = result.Id,
                Name = result.Name,
                Pis = result.Pis
            } : null;
        }
    }
}
