using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domian.Account.Common
{
    public class TokenDetailRequest
    {
        public Dictionary<string,object>  TokenClaims { get; set; }
    }
}
