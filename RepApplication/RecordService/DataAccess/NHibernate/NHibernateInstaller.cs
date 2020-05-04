using FluentNHibernate.Cfg;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using NHibernate.Bytecode;
using NHibernate.Cfg;
using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Driver;
using RecordService.Domain;
using RecordService.NHMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordService.DataAccess.NHibernate
{
    public static class NHibernateInstaller
    {
        public static IServiceCollection AddNHibernate(this IServiceCollection services, string connectionString)
        {
            var configuration = new Configuration();
            //configuration.DataBaseIntegration(db =>
            //{
            //    db.Dialect<PostgreSQL83Dialect>();
            //    db.Driver<NpgsqlDriver>();
            //    db.ConnectionProvider<DriverConnectionProvider>();
            //    db.BatchSize = 500;
            //    db.IsolationLevel = System.Data.IsolationLevel.ReadCommitted;
            //    db.LogSqlInConsole = false;
            //    db.ConnectionString = connectionString;
            //    db.Timeout = 30;
            //    db.SchemaAction = SchemaAutoAction.Update;
            //});

            configuration.DataBaseIntegration(db =>
            {
                db.Dialect<MsSql2008Dialect>();
                db.Driver<SqlClientDriver>();
                db.ConnectionProvider<DriverConnectionProvider>();
                db.BatchSize = 500;
                db.IsolationLevel = System.Data.IsolationLevel.ReadCommitted;
                db.LogSqlInConsole = false;
                db.ConnectionString = connectionString;
                db.Timeout = 30;
                db.SchemaAction = SchemaAutoAction.Update;
            });

            configuration.Proxy(p => new StaticProxyFactoryFactory());
            configuration.Cache(c => c.UseQueryCache = false);
            configuration.AddAssembly(typeof(NHibernateInstaller).Assembly);

            services.AddSingleton(Fluently.Configure(configuration).Mappings(m => m.FluentMappings.GetMappings()).BuildSessionFactory());
            services.AddScoped(s => s.GetService<ISessionFactory>().OpenSession());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        private static void GetMappings(this FluentMappingsContainer map)
        {
            map.Add<RecordMap>();
            map.Add<EmployeeMap>();
        }
    }
}
