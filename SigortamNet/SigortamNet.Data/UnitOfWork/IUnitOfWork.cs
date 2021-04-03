using SigortamNet.Data.Entities;
using SigortamNet.Data.Repositories;
using System.Threading.Tasks;

namespace SigortamNet.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        UowTransaction BeginTransaction();
        Task<int> SaveChangesAsync();
    }
}
