using System.Text;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Ocelot.Provider.Eureka;
using Ocelot.Cache.CacheManager;
using Ocelot.Middleware;

namespace RepApplication.Api.Gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var key = Encoding.ASCII.GetBytes("THIS_IS_A_RANDOM_SECRET_2e7a1e80-16ee-4e52-b5c6-5e8892453459");

            return WebHost.CreateDefaultBuilder(args)
                //.UseUrls("http://localhost:5020")
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config
                        .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                        .AddJsonFile("appsettings.json", true, true)
                        .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true,
                            true)
                        .AddJsonFile("ocelot.json", false, false)
                        .AddEnvironmentVariables();
                })
                .ConfigureServices(s =>
                {
                    s.AddCors();
                    
                    s.AddAuthentication(x =>
                    {
                        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                    .AddJwtBearer("ApiSecurity", x =>
                    {
                        x.RequireHttpsMetadata = false;
                        x.SaveToken = true;
                        x.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(key),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };

                    });
                    
                    s.AddOcelot().AddEureka().AddCacheManager(x => x.WithDictionaryHandle());
                })
                .Configure(a =>
                {
                    
                    var appSettings = new AppSettings();
                    a.ApplicationServices.GetService<IConfiguration>()
                        .GetSection("AppSettings")
                        .Bind(appSettings);

                    a.UseCors
                    (b => b
                        .WithOrigins(appSettings.AllowedChatOrigins)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                    );
                    
                    a.UseOcelot().Wait();

                })
                .Build();
        }
    }
}
