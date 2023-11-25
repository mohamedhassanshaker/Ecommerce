using Ecommerce.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Contracts.Cart
{
    public class CartItemDto : Dto
    {
        public Guid ID { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        public string Name { get;   set; }
    }

}
