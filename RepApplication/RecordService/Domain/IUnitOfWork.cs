using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordService.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IRecordRepository RecordRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        Task CommitChanges();
    }
}
