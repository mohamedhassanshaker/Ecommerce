using Ecommerce.Domian.CartAggregate.Entities;
using Ecommerce.Domian.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domian.CartAggregate.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}
