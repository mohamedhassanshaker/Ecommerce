using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domian.Account.Common
{
    public class TokenDetailResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }

        public DateTime Expires { get; set; }
    }
}
