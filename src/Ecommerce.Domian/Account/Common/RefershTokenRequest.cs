using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domian.Account.Common
{
    public  class RefershTokenRequest
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
