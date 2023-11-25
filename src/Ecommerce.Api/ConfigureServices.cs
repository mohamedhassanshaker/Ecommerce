using Ecommerce.Api.Installers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Api
{
    public static class ConfigureServices
    {
        public static void InstallApiServices(this IServiceCollection services, IConfiguration configuration)
        {
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
