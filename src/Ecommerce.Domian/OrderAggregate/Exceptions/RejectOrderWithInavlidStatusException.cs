using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domian.OrderAggregate.Exceptions
{
    public class RejectOrderWithInavlidStatusException:Exception
    {
        public RejectOrderWithInavlidStatusException(string message):base(message) { }
    }
}
