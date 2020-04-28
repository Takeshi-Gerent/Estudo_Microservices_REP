using CompanyService.Api.Queries.Dtos;
using Microsoft.Extensions.Configuration;
using RestEase;
//using Steeltoe.Common.Discovery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeService.RestClients
{
    public interface ICompanyClient
    {
        [Get]
        Task<CompanyDto> FindCompanyByCode([Query]int codeType, string code);
    }

    public class CompanyClient : ICompanyClient
    {
        private readonly ICompanyClient client;

        public CompanyClient(IConfiguration configuration)//, IDiscoveryClient discoveryClient)
        {
            //var handler = new DiscoveryHttpClientHandler(discoveryClient);
            var httpClient = new HttpClient//new HttpClient(handler, false)
            {
                BaseAddress = new Uri(configuration.GetValue<string>("CompanyServiceUri"))
            };
            client = RestClient.For<ICompanyClient>(httpClient);
        }

        public async Task<CompanyDto> FindCompanyByCode([Query] int codeType, string code)
        {
            return await client.FindCompanyByCode(codeType, code);
        }
    }
}
