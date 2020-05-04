using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecordService.Api.Commands
{
    public class RegisterRecordCommand : IRequest<RegisterRecordResult>
    {
        public string EmployeePis { get; set; }
        public int TimeZone { get; set; }
        public bool DaylightSavingTime { get; set; }
    }
}
