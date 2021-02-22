using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using wmj.userManagerServer.Domain.Interfaces;
using wmj.userManagerServer.Domain.Models;
using wmj.userManagerServer.Infra;

namespace wmj.userManagerServer.Domain.Services
{
    public class BaseServices<TEntity, TId> : IBaseServices<TEntity, TId> where TEntity : BaseEntity<TId>
    {
        protected AppDbContext DbContext;

        public BaseServices(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected  DbSet<TEntity> Entry => DbContext.Maintain<TEntity>();
        public TEntity Get(TId id)
        {
            return Entry.FirstOrDefault(x => x.Id.Equals(id));
        }
        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return Entry.Where(predicate);
        }
        public IEnumerable<TEntity> GetEnumerable(Func<TEntity, bool> predicate)
        {
            return Entry.Where(predicate);
        }
        public void Add(TEntity entity)
        {
            Entry.Add(entity);
            SaveChanges();
        }
        public async Task Update(TId id, TEntity newEntity)
        {
            var entity = await Entry.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (entity != null)
            {
                ObjectHelper.CopyPropertyToTarget(newEntity, entity, new[] { "id" });
                SaveChanges();
            }
        }
        public async Task UpdateAsync(TId id, Action<TEntity> update)
        {
            var entity = await Entry.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (entity != null && update != null)
            {
                update(entity);
                SaveChanges();
            }
        }
        public void Delete(TId id)
        {
            var item = Entry.FirstOrDefault(x => x.Id.Equals(id));
            if (item != null)
            {
                Entry.Remove(item);
                SaveChanges();
            }
        }

        public void SaveChanges(bool acceptAllChangesOnSuccess = true)
        {
            DbContext.SaveChanges(acceptAllChangesOnSuccess);
        }
    }
}
