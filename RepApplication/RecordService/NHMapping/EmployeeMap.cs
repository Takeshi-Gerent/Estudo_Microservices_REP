using FluentNHibernate.Mapping;
using RecordService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordService.NHMapping
{
    public class EmployeeMap: ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Id(p => p.Id).GeneratedBy.Identity();
            Map(p => p.Pis).Not.Nullable();
        }
    }
}
