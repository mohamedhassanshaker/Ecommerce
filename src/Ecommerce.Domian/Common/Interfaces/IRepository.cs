using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Timers;
using Ecommerce.Domian.OrderAggregate.Specification;

namespace Ecommerce.Domian.Common.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IQueryable<TEntity>> Find(ISpecification<TEntity> spec);
        Task<TEntity> FindByID(Guid ID);
        Task<IQueryable<TEntity>> GetAll();
        Task<bool> Insert(TEntity entity);
        Task<bool> Delete(TEntity entity);
        Task<bool> Update(TEntity entity);
    }
}