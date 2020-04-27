using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyService.Domain
{
    public enum CompanyCodeType
    {
        CNPJ,
        CEI
    }

    public class Company
    {
        public virtual int? Id { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual CompanyCodeType CodeType { get; protected set; }
        public virtual string Code { get; protected set; }
        public virtual string Address { get; protected set; }

        protected Company() { }

        public static Company New(string name, CompanyCodeType codeType, string code, string address)
        {
            return new Company(name, codeType, code, address);
        }

        protected Company(string name, CompanyCodeType codeType, string code, string address)
        {
            Id = null;
            Name = name;
            CodeType = codeType;
            Code = code;
            Address = address;
        }
    }
}
