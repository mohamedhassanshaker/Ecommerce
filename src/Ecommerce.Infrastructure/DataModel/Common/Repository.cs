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
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;


        public Repository(ApplicationDbContext dbContext)
        {

            _dbContext = dbContext;
        }

        public async Task<bool> Delete(TEntity entity)
        {
            try
            {
                _dbContext.Set<TEntity>().Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IQueryable<TEntity>> GetAll()
        {
            return _dbContext.Set<TEntity>().AsQueryable<TEntity>();
        }



        public async Task<bool> Insert(TEntity entity)
        {

            try
            {
                await _dbContext.Set<TEntity>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return  true ;
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
                _dbContext.Set<TEntity>().Update(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }

        }


        public async Task<IQueryable<TEntity>> Find(ISpecification<TEntity> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<TEntity>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return secondaryResult
                            .Where(spec.Criteria)
                            .AsQueryable();
        }

        public async Task<TEntity> FindByID(Guid ID)
        {
            return await _dbContext.Set<TEntity>()
                .Where(en => en.ID == ID)
                .FirstOrDefaultAsync();
        }


    }
}