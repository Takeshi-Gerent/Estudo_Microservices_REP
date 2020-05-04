using MediatR;
using RecordService.Api.Commands;
using RecordService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RecordService.Commands
{
    public class RegisterRecordHandler : IRequestHandler<RegisterRecordCommand, RegisterRecordResult>
    {
        private readonly IUnitOfWork uow;
        
        public RegisterRecordHandler(IUnitOfWork uow)
        {
            this.uow = uow ?? throw new ArgumentNullException(nameof(uow));
        }

        public async Task<RegisterRecordResult> Handle(RegisterRecordCommand request, CancellationToken cancellationToken)
        {
            var employee = await uow.EmployeeRepository.FindByPis(request.EmployeePis);

            var record = Record.New(
                SysTime.CurrentUtcTime,
                request.TimeZone,
                request.DaylightSavingTime,
                employee);

            uow.RecordRepository.Add(record);
            await uow.CommitChanges();

            return new RegisterRecordResult { Id = record.Id, RecordIsntant = record.RecordInstant };
            
        }
    }
}
