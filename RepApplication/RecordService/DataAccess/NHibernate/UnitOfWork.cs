using NHibernate;
using RecordService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordService.DataAccess.NHibernate
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISession session;
        private readonly ITransaction tx;
        private readonly RecordRepository recordRepository;
        private readonly EmployeeRepository employeeRepository;

        public IRecordRepository RecordRepository => recordRepository;
        public IEmployeeRepository EmployeeRepository => employeeRepository;

        public UnitOfWork(ISession session)
        {
            this.session = session;
            tx = session.BeginTransaction();
            recordRepository = new RecordRepository(session);
            employeeRepository = new EmployeeRepository(session);
        }

        public async Task CommitChanges()
        {
            await tx.CommitAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                tx?.Dispose();
            }

        }
    }
}
