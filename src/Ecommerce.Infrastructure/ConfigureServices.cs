using Ecommerce.Domian.Account.Common;
using Ecommerce.Infrastructure.Common;
using Ecommerce.Infrastructure.Installers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;

namespace Ecommerce.Infrastructure
{
    public static class ConfigureServices
    {
        public static void InstallInfrastructureServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<RedisSettings>(configuration.GetSection(RedisSettings.SectionName));
            services.Configure<JWTSetting>(configuration.GetSection(JWTSetting.SectionName));

            var baseInstallers = typeof(IInstaller).Assembly.ExportedTypes.Where(x =>
                typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && x.IsAbstract).Select(Activator.CreateInstance)
                .Cast<IInstaller>().ToList();

            var installers = typeof(IInstaller).Assembly.ExportedTypes.Where(x =>
                typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance)
                .Cast<IInstaller>().ToList();

            baseInstallers.ForEach(installer => installer.InstallServices(services, configuration));
            installers.ForEach(installer => installer.InstallServices(services, configuration));
        }
    }
}
