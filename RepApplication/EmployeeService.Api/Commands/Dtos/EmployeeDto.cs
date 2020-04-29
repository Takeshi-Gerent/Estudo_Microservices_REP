using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeService.Api.Commands.Dtos
{
    public class EmployeeDto
    {
        public string Name { get; set; }
        public string Pis { get; set; }
        public string CompanyCodeType { get; set; }
        public string CompanyCode { get; set; }
    }
}
