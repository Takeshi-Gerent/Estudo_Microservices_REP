using NHibernate;
using NHibernate.Linq;
using RecordService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordService.DataAccess.NHibernate
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ISession session;

        public EmployeeRepository(ISession session)
        {
            this.session = session;
        }

        public async Task<Employee> FindByPis(string pis)
        {
            return await session.Query<Employee>().FirstOrDefaultAsync(p => p.Pis == pis);
        }

    }
}
