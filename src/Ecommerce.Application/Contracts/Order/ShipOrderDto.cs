using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Contracts.Order
{
    public  class ShipOrderDto :Dto
    {
        public Guid OrderID { get; set; }
    }
}
