using Ecommerce.Domian.OrderAggregate;
using Ecommerce.Domian.OrderAggregate.Interfaces;
using Ecommerce.Infrastructure.DataModel.Common;

namespace Ecommerce.Infrastructure.DataModel.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
