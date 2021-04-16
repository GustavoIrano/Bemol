using bemol.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bemol.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Add(TEntity entity);
        Task AddRange(IEnumerable<TEntity> entities);
        Task<TEntity> GetById(Guid id);
        Task<List<TEntity>> GetAll();
        Task Update(TEntity entity);
        Task Remove(Guid id);
        Task<int> SaveChanges();
        Task<int> GetTotalCount();
    }
}
