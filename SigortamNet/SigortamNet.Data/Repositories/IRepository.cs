using SigortamNet.Data.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SigortamNet.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task AddAsync(TEntity entity);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> query);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> query);

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> query = null);
    }
}
