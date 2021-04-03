using Microsoft.EntityFrameworkCore;
using SigortamNet.Data.Contexts;
using SigortamNet.Data.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SigortamNet.Data.Repositories
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity 
    {
        private readonly DbSet<TEntity> _dbSet;

        public EfRepository(SigortamNetContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            if(entity == null)
                throw new ArgumentNullException($"Entity boş olamaz. Tip: {nameof(TEntity)}");

            _dbSet.Add(entity);
        }

        public IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> query = null)
        {
            return query == null ? _dbSet : _dbSet.Where(query);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> query)
        {
            return _dbSet.SingleOrDefault(query);
        }
    }
}
