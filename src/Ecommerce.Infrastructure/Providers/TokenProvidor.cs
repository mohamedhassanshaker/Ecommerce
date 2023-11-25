using Ecommerce.Domian.Account.Common;
using Ecommerce.Domian.Account.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Providers
{
    public class TokenProvidor : ITokenProvider
    {

        private readonly IOptions<JWTSetting> jWTSetting;

        public TokenProvidor(IOptions<JWTSetting> jWTSetting)
        {
            this.jWTSetting = jWTSetting;
        }
        public Task<TokenDetailResponse> GetToken(TokenDetailRequest request)
        {

            Claim []claims = request.TokenClaims.Select(en =>new Claim(en.Key, en.Value.ToString())).ToArray();

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jWTSetting.Value.SecritKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jWTSetting.Value.Issuer,
                audience: jWTSetting.Value.Issuer,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Set expiration time
                signingCredentials: creds
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            return Task.FromResult( new TokenDetailResponse {Token= tokenHandler.WriteToken(token) });
        }

        public Task<TokenDetailResponse> RefershToken(RefershTokenRequest request)
        {
            return Task.FromResult(new TokenDetailResponse());
        }

        public Task<bool> ValidateToken(ValidateTokenRequest request)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jWTSetting.Value.SecritKey));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,

                ValidateIssuer = true,
                ValidIssuer = jWTSetting.Value.Issuer, // Replace with your issuer

                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero // You can adjust the tolerance for the expiration time check
            };

            try
            {
                tokenHandler.ValidateToken(request.Token, tokenValidationParameters, out _);
                return Task.FromResult(true);
            }
            catch (SecurityTokenException)
            {
                // Token validation failed
                return Task.FromResult(false);
            }
        }
    }
}
