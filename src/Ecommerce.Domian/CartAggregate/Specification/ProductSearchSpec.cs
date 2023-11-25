using Ecommerce.Domian.CartAggregate.Entities;
using Ecommerce.Domian.Common;
using Ecommerce.Domian.OrderAggregate.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domian.OrderAggregate.Specification
{
    public class ProductSearchSpec : BaseSpecification<Product>
    {
        public ProductSearchSpec(string Name,decimal PriceFrom,Decimal PriceTo)
            : base(spec => spec.Name.Contains(Name) && spec.Price>PriceFrom && spec.Price<PriceTo)
        {
             
        }
    }
}
