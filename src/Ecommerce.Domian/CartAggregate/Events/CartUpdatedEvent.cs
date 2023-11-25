using Ecommerce.Domian.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domian.CartAggregate.Events
{
    public class CartUpdatedEvent : BaseEvent
    {
        public CartUpdatedEvent(Cart cart)
        {
            Cart = cart;
        }

        public Cart Cart { get; }
    }
}
