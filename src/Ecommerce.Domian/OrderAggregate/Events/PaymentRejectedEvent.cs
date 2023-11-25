using Ecommerce.Domian.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domian.OrderAggregate.Events
{
    public class PaymentRejectedEvent : BaseEvent
    {
        public PaymentRejectedEvent(Order order)
        {
            Order = order;
        }

        public Order Order { get; }
    }
}
