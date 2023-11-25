using Ecommerce.Application.Dto;
using Ecommerce.Domian.CartAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Contracts.Product
{
    public class ProductSearchDto : Dto
    {
       
        public string Name { get; set; }
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; }
    }
}
