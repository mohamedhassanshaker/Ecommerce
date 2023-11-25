using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ecommerce.Domian.Common;
using Ecommerce.Domian.Common.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce.Infrastructure.DataModel.Common
{
    public abstract class DistributedCashRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ICacheProvider cacheProvider;

        public DistributedCashRepository(ICacheProvider cacheProvider)
        {
            this.cacheProvider = cacheProvider;
        }

        public async Task<bool> Delete(TEntity entity)
        {
            try
            {
                this.cacheProvider.RemoveFromCache($"{typeof(TEntity).Name}-{entity.ID}");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IQueryable<TEntity>> GetAll()
        {
            throw new NotImplementedException();
            return null;
        }



        public async Task<bool> Insert(TEntity entity)
        {

            try
            {
                this.cacheProvider.SetCache($"{typeof(TEntity).Name}-{entity.ID}", entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> Update(TEntity entity)
        {
            try
            {
                this.cacheProvider.SetCache($"{typeof(TEntity).Name}-{entity.ID}", entity);
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<IQueryable<TEntity>> Find(ISpecification<TEntity> spec)
        {
            throw new NotImplementedException();
            return null;
        }

        public async Task<TEntity> FindByID(Guid ID)
        {
            
            return this.cacheProvider.GetFromCache<TEntity>($"{typeof(TEntity).Name}-{ID}").Result;
        }


    }
}