using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordService.Domain
{
     public interface IRecordRepository
    {
        void Add(Record record);        
    }
}
