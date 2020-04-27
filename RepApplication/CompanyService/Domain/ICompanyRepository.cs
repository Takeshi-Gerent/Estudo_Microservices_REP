using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyService.Domain
{
    public interface ICompanyRepository
    {
        void Add(Company company);
    }
}
