using Ecommerce.Domian.Common;
using Ecommerce.Domian.OrderAggregate.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domian.OrderAggregate.Specification
{
    public class OrderByOrderNumberSpec : BaseSpecification<Order>
    {
        public OrderByOrderNumberSpec(string OrderNumber)
            : base(b => b.OrderNumber == OrderNumber)
        {
             
        }
    }
}
