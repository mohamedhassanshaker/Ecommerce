using Ecommerce.Domian.Account.Common;
using Ecommerce.Infrastructure.Common;
using Ecommerce.Infrastructure.DataModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System.Text;

namespace Ecommerce.Infrastructure.Installers
{
    public class TokenValidatorInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration )
        {
            IOptions<JWTSetting> jwtSettings= (IOptions <JWTSetting> )services.BuildServiceProvider().GetService(typeof(IOptions<JWTSetting>));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Value.SecritKey));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Value.Issuer,
                        ValidAudience = jwtSettings.Value.Issuer,
                        IssuerSigningKey = key,
                        ClockSkew = TimeSpan.Zero
                    };
                });
        }
    }
}
