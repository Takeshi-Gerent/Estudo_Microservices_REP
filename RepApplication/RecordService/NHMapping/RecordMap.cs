using FluentNHibernate.Mapping;
using RecordService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordService.NHMapping
{
    public class RecordMap: ClassMap<Record>
    {
        public RecordMap()
        {
            Id(p => p.Id).GeneratedBy.Identity();
            Map(p => p.RecordInstant).Not.Nullable();
            Map(p => p.RecordInstantUTC).Not.Nullable();
            Map(p => p.TimeZone).Not.Nullable();
            Map(p => p.DaylightSavingTime).Not.Nullable();

            References(p => p.Employee).Column("EmployeeId").Fetch.Select().Not.Nullable().Cascade.None();
        }
    }
}
