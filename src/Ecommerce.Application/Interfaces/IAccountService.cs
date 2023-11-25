using Ecommerce.Application.Contracts.Account;
using Ecommerce.Domian.Account.Common;

namespace Ecommerce.Application.Interfaces
{
    public interface IAccountService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
    }
}