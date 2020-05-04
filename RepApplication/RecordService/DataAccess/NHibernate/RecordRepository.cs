using NHibernate;
using RecordService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordService.DataAccess.NHibernate
{
    public class RecordRepository : IRecordRepository
    {
        private readonly ISession session;

        public RecordRepository(ISession session)
        {
            this.session = session;
        }

        public void Add(Record record)
        {
            session.Save(record);
        }
    
    }
}
