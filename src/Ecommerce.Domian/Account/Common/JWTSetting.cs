using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domian.Account.Common
{
    public class JWTSetting
    {
        public const string SectionName = "JWTSettings";
        public string SecritKey { get; set; }
        public int MinutesToExpire { get; set; }
        public int MinutesToRefresh { get; set; }
        public string Issuer { get; set; }
    }
}
