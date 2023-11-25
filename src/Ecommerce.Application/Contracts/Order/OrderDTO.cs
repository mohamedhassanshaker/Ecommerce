using Ecommerce.Application.Dto;
using Ecommerce.Domian.CartAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Contracts.Order
{
    public class OrderDTO : Dto
    {
        public Guid ID { get; set; }
        public long OrderNumber { get; set; }
        public Guid CartID { get; set; }
        public decimal Total { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }
    }
}
