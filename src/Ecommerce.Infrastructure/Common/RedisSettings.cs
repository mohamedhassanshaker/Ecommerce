using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Common
{
    public class RedisSettings
    {
        public const string SectionName = "Cashing";
        
        public string Provider { get; set; }
        public string ConnStr { get; set; }
        public int MinutesToExpire { get; set; }

    }
}
