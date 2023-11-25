using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Contracts.Account
{
    public class LoginResponseDto
    {
        public int code { get; set; }
        public string message { get; set; }
        public string token { get; set; }
        public string refreshToken { get; set; }
        public DateTime expires { get; set; }
    }
}
