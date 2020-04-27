using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeService.Api.Queries.Dtos
{
    public class EmployeeDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Pis { get; set; }        
    }
}
