using CompanyService.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyService.NHMapping
{
    public class CompanyMap : ClassMap<Company>
    {
        public CompanyMap()
        {
            Id(p => p.Id).GeneratedBy.Identity();
            Map(p => p.Name);
            Map(p => p.CodeType).CustomType<CompanyCodeType>();
            Map(p => p.Code);
            Map(p => p.Address);
        }
    }
}
