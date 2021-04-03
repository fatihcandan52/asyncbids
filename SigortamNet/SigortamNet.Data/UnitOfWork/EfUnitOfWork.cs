using SigortamNet.Data.Contexts;
using SigortamNet.Data.Entities;
using SigortamNet.Data.Extensions;
using SigortamNet.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SigortamNet.Data.UnitOfWork
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly SigortamNetContext _context;
        private readonly Dictionary<string, dynamic> _repositoryDictionary; //TODO: 

        public EfUnitOfWork(SigortamNetContext context)
        {
            _context = context;
            _repositoryDictionary = new Dictionary<string, dynamic>();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            var entityName = typeof(TEntity).Name;

            var repositoryCreated = _repositoryDictionary.ContainsKey(entityName);

            if (!repositoryCreated)
            {
                var newRepository = new EfRepository<TEntity>(_context); // TODO: 
                _repositoryDictionary.Add(entityName, newRepository);
            }

            return _repositoryDictionary[entityName];
        }

        public UowTransaction BeginTransaction()
        {
            return _context.Database.CreateOrGetCurrentTransaction();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        // TODO: 
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
