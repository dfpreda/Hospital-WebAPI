using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hospital.Repositories.Repositories.Contracts
{
    public interface IBaseRepository<TEntity>
    {
        IQueryable<TEntity> Get(
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        Task<TEntity> SingleOrDefaultAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        Task<TEntity> InsertAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Dispose();
    }
}