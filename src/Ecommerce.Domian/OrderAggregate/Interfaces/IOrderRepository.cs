using Ecommerce.Domian.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domian.OrderAggregate.Interfaces
{
    public interface IOrderRepository:IRepository<Order>
    {
    }
}
