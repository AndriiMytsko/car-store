using CarStore.Dal.Entities;
using CarStore.Dal.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Dal.Ef.Repositories
{
    public abstract class Repository<TEntity>
            : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly DbSet<TEntity> DbSet;
        protected CarStoreDbContext DbContext { get; }

        protected Repository(
          CarStoreDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
        }

        protected IQueryable<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await GetAll().ToArrayAsync();
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await DbContext.FindAsync<TEntity>(id);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Added;

            await DbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;

            await DbContext.SaveChangesAsync();
        }

        public virtual async Task RemoveAsync(int id)
        {
            var entity = await DbSet.FindAsync(id);
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Deleted;

            await DbContext.SaveChangesAsync();
        }
    }
}
