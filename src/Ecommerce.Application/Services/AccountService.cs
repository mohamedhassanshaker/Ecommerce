using Ecommerce.Application.Contracts.Account;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domian.Account.Common;
using Ecommerce.Domian.Account.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly ITokenProvider tokenProvider;
        private readonly IOptions<JWTSetting> jwtsetting;

        public AccountService(ITokenProvider tokenProvider, IOptions<JWTSetting> jwtsetting)
        {
            this.tokenProvider = tokenProvider;
            this.jwtsetting = jwtsetting;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            LoginResponseDto response = new LoginResponseDto();
            try
            {
                if (request.UserName == "admin" && request.Password == "password")
                {
                    var token = await tokenProvider.GetToken(new Domian.Account.Common.TokenDetailRequest
                    {
                        TokenClaims = new Dictionary<string, object>
                    {
                        {  "userID", request.UserName},
                        {  "Role", "admin"}
                    }
                    });
                    response.token = token.Token;
                    response.expires = DateTime.UtcNow.AddMinutes(jwtsetting.Value.MinutesToExpire);

                }
                else
                {
                    response.code = -100;
                    response.message = "invalid authintacation details";
                }

            }
            catch (Exception e)
            {
                response.code = -200;
                response.message = e.Message;
            }

            return response;
        }
    }
}
