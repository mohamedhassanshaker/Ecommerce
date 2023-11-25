using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domian.CartAggregate.Exceptions
{
    public class ItemNotExistException:Exception
    {
        public ItemNotExistException(string message):base(message) { }
    }
}
