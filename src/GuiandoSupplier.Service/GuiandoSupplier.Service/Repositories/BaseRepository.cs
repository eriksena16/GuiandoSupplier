using GuiandoSupplier.Domain.Entities;
using GuiandoSupplier.Domain.Interfaces.Repositories;
using GuiandoSupplier.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GuiandoSupplier.Service.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly DbSet<TEntity> DbSet;
        protected readonly GuiandoContext Db;

        public BaseRepository(GuiandoContext context)
        {
            DbSet = context.Set<TEntity>();
            Db = context;
        }

        public virtual async Task Add(TEntity obj)
        {
            DbSet.Add(obj);
            await SaveChanges();
        }
        public virtual async Task Update(TEntity obj)
        {
            DbSet.Update(obj);
            await SaveChanges();
        }
        public virtual async Task<TEntity> Get(long id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<List<TEntity>> Get()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Delete(long id)
        {
            DbSet.Remove(new TEntity { Id = id });

            await SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}