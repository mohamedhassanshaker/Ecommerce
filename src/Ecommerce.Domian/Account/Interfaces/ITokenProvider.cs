using Ecommerce.Domian.Account.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domian.Account.Interfaces
{
    public interface ITokenProvider
    {
        Task<TokenDetailResponse> GetToken(TokenDetailRequest request);

        Task<bool> ValidateToken(ValidateTokenRequest request);

        Task<TokenDetailResponse> RefershToken(RefershTokenRequest request);
    }
}
