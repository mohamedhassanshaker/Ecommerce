using Ecommerce.Domian.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domian.OrderAggregate.Events
{
    public class InventoryUpdatedEvent : BaseEvent
    {
        public InventoryUpdatedEvent(Order order)
        {
            Order = order;
        }

        public Order Order { get; }
    }
}
