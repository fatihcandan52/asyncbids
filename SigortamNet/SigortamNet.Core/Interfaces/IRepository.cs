using System;
using System.Linq.Expressions;

namespace SigortamNet.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        TEntity Get(Expression<Func<TEntity, bool>> query);
    }
}
