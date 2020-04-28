using EmployeeService.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.RestClients
{
    public static class RestClientsInstaller
    {
        public static IServiceCollection AddCompanyRestClient(this IServiceCollection services)
        {
            services.AddSingleton(typeof(ICompanyClient), typeof(CompanyClient));
            services.AddSingleton(typeof(ICompanyService), typeof(CompanyService));
            return services;
        }
    }
}
