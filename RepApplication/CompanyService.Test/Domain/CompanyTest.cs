using CompanyService.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CompanyService.Test.Domain
{
    public class CompanyTest
    {
        [Fact]
        public void New()
        {
            var company = Company.New("Nome da Companhia", CompanyCodeType.CNPJ, "000001", "Rua sem nome");

            Assert.Equal("Nome da Companhia", company.Name);
            Assert.Equal(CompanyCodeType.CNPJ, company.CodeType);
            Assert.Equal("000001", company.Code);
            Assert.Equal("Rua sem nome", company.Address);
        }
    }
}
