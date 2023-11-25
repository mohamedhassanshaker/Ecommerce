
using Ecommerce.Domian.Account.Interfaces;
using Ecommerce.Domian.CartAggregate.Interfaces;
using Ecommerce.Domian.Common.Interfaces;
using Ecommerce.Domian.OrderAggregate.Interfaces;
using Ecommerce.Infrastructure.Common;
using Ecommerce.Infrastructure.DataModel;
using Ecommerce.Infrastructure.DataModel.Repositories;
using Ecommerce.Infrastructure.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Infrastructure.Installers
{
    public class DIInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddSingleton<ICacheProvider, CacheProvider>();
            services.AddSingleton<ITokenProvider, TokenProvidor>();

        }
    }
}
