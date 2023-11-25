using Ecommerce.Domian.CartAggregate.Entities;
using Ecommerce.Domian.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domian.OrderAggregate.Entities
{
    public class OrderDetail : BaseAuditableEntity
    {
        public Guid ProductID { get; private set; }
        public Product Product { get; private set; }
        public int Qty { get; private set; }
        public decimal Price { get; private set; }

        public OrderDetail()
        {

        }
        public OrderDetail(Guid _ProductID,int _Qty,decimal _Price)
        {
            ProductID = _ProductID;
            Qty = _Qty;
            Price = _Price;
        }

    }
}
