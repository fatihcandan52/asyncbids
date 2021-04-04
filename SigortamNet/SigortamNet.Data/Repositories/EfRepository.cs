using Microsoft.EntityFrameworkCore;
using SigortamNet.Data.Contexts;
using SigortamNet.Data.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SigortamNet.Data.Repositories
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;

        public EfRepository(SigortamNetContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException($"Entity boş olamaz. Tip: {nameof(TEntity)}");

            await _dbSet.AddAsync(entity);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> query = null)
        {
            return query == null ? _dbSet : _dbSet.Where(query);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> query)
        {
            return await _dbSet.SingleOrDefaultAsync(query);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> query)
        {
            return await _dbSet.FirstOrDefaultAsync(query);
        }
    }
}
