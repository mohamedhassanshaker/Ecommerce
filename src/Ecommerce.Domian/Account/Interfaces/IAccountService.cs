
using Ecommerce.Domian.Account.Common;

namespace Ecommerce.Application.Services
{
    public interface IAccountService
    {
        Task<TokenDetailResponse> LoginAsync(LoginRequest request);
    }
}