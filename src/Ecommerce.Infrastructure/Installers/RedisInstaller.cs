using Ecommerce.Infrastructure.Common;
using Ecommerce.Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using StackExchange.Redis; 


namespace Ecommerce.Infrastructure.Installers
{
    public class RedisInstaller : IInstaller
    {
         
 
        public void InstallServices(IServiceCollection services, IConfiguration configuration )
        {
            IOptions<RedisSettings> redisSettings= (IOptions < RedisSettings > )services.BuildServiceProvider().GetService(typeof(IOptions<RedisSettings>));
            string Provider = redisSettings.Value.Provider;
            switch(Provider)
            {
                case "Redis":
                     
                    services.AddStackExchangeRedisCache(options =>
                    {
                        options.Configuration = redisSettings.Value.ConnStr;
                        options.InstanceName = "ecommerce";
                    });
                    break;
                case "MemCash":
                default:
                    services.AddDistributedMemoryCache();
                    break;
            }

            

        }
    }
}
