using Ecommerce.Application.Dto;
using Ecommerce.Domian.CartAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Contracts.Product
{
    public class ProductDto : Dto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Balance { get; set; }
    }
}
