using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace wmj.userManagerServer.Domain.Interfaces
{
    public interface IBaseServices<TEntity, TId>
    {
        void Add(TEntity entity);
        void Delete(TId id);
        TEntity Get(TId id);
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> GetEnumerable(Func<TEntity, bool> predicate);
        void SaveChanges(bool acceptAllChangesOnSuccess = true);
        Task Update(TId id, TEntity newEntity);
        Task UpdateAsync(TId id, Action<TEntity> update);
    }
}
