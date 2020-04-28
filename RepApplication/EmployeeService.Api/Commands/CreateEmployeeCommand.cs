using EmployeeService.Api.Commands.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeService.Api.Commands
{
    public class CreateEmployeeCommand : IRequest<CreateEmployeeResult>
    {
        public EmployeeDto Employee { get; set; }
    }
}
