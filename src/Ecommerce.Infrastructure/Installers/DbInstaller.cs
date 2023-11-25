using Ecommerce.Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
 


namespace Ecommerce.Infrastructure.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
           services.AddDbContext<ApplicationDbContext>(options => 
           options.UseSqlServer(configuration.GetConnectionString("constr"), b => b.MigrationsAssembly("Ecommerce.Migrations")), ServiceLifetime.Scoped
           );

        }
    }
}
