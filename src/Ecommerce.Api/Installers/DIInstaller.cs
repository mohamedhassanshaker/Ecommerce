using Ecommerce.Api.Filters;
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Services;
using Ecommerce.Domian.Common.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Ecommerce.Domian.Account.Common;
using Ecommerce.Domian.Common;

namespace Ecommerce.Api.Installers
{
    public class DIInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {


            services.AddScoped<LogFilters>();
            services.AddLogging(config =>
            {
                config.AddConfiguration(configuration.GetSection("Logging"));
                config.ClearProviders();
                config.AddEventLog(options =>
                {
                    options.LogName = "MyLog";
                    options.SourceName = "MyLog"; 
                });
            });

        }
    }
}
