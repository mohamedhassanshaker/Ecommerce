using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domian.OrderAggregate.Enums
{
    public enum OrderStatus
    {
        New=0, 
        PendingPayment=1,
        PaymentAccepted=2, 
        PaymentRejected=3,
        PendingShiping=4,
        Shipped=5,
        Completed=6
    }
}
