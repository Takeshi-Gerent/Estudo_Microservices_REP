using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordService.Domain
{
    public class Employee
    {
        public virtual long Id { get; protected set; }
        public virtual string Pis { get; protected set; }

        protected Employee() { }

        private Employee(int id, string pis)
        {
            Id = id;
            Pis = pis;            
        }

        public static Employee ForRecord(int id, string pis)
        {
            return new Employee(id, pis);
        }
    }
}
