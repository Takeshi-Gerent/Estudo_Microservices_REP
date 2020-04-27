using CompanyService.Domain;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyService.DataAccess.NHibernate
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ISession session;

        public CompanyRepository(ISession session)
        {
            this.session = session;
        }

        public void Add(Company company)
        {
            session.Save(company);
        }
    }
}
