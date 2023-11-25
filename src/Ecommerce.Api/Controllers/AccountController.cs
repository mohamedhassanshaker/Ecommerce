using Ecommerce.Api.Filters;
using Ecommerce.Application.Contracts.Account;
using Ecommerce.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Api.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    [ServiceFilter(typeof(LogFilters))]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        [HttpPost("Login")]
        public Task<LoginResponseDto> Login(LoginRequestDto request) {
            return accountService.LoginAsync(request);
        }
    }
}
