using Ecommerce.Domian.CartAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Contracts.Cart
{
    public class CartDto : Dto
    {
        public Guid ID { get; set; }
        public long RefernceNumber { get; set; }
        public decimal Total { get; set; }
        public List<CartItemDto> CartItems { get; set; }
    }
}
