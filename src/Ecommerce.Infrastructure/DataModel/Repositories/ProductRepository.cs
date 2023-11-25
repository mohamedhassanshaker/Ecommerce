using Ecommerce.Domian.CartAggregate;
using Ecommerce.Domian.CartAggregate.Entities;
using Ecommerce.Domian.CartAggregate.Interfaces;
using Ecommerce.Domian.OrderAggregate;
using Ecommerce.Infrastructure.DataModel.Common;

namespace Ecommerce.Infrastructure.DataModel.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
