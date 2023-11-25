using Ecommerce.Domian.CartAggregate;
using Ecommerce.Domian.CartAggregate.Interfaces;
using Ecommerce.Domian.Common.Interfaces;
using Ecommerce.Domian.OrderAggregate;
using Ecommerce.Infrastructure.DataModel.Common;
using Microsoft.EntityFrameworkCore;
using static Ecommerce.Infrastructure.DataModel.Repositories.CartRepository;

namespace Ecommerce.Infrastructure.DataModel.Repositories
{
    public class CartRepository : Repository<Cart>,ICartRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CartRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Cart> FindByID(Guid ID)
        {
            return await _dbContext.Set<Cart>()
                .Include(en=>en.CartItems)
                .ThenInclude(en=>en.Product)
                .Where(en => en.ID == ID)
                .FirstOrDefaultAsync();
        }
        public async Task<bool> Update(Cart entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                foreach (var detail in entity.CartItems)
                {
                    if (detail.IsDeleted && !detail.IsNew)
                        _dbContext.Entry(detail).State = EntityState.Deleted;
                    else
                        _dbContext.Entry(detail).State = detail.IsNew ? EntityState.Added : EntityState.Modified;

                }
                await _dbContext.SaveChangesAsync();
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
