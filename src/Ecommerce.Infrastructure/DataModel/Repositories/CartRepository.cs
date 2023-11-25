using Ecommerce.Domian.CartAggregate;
using Ecommerce.Domian.CartAggregate.Interfaces;
using Ecommerce.Domian.Common.Interfaces;
using Ecommerce.Domian.OrderAggregate;
using Ecommerce.Infrastructure.DataModel.Common;
using Microsoft.EntityFrameworkCore;
using static Ecommerce.Infrastructure.DataModel.Repositories.CartRepository;

namespace Ecommerce.Infrastructure.DataModel.Repositories
{
    public class CartRepository : DistributedCashRepository<Cart>,ICartRepository
    {
        private readonly ICacheProvider cacheProvider;
        public CartRepository(ICacheProvider cacheProvider) : base(cacheProvider)
        {
            this.cacheProvider = cacheProvider;
        }
        
    }
}
