
using EmployeeService.Api.Queries.Dtos;
using MediatR;

namespace EmployeeService.Api.Queries
{
    public class FindEmployeeByPisQuery : IRequest<EmployeeDto>
    {
        public string Pis { get; set; }
    }
}
