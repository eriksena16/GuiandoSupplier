using GuiandoSupplier.Domain.Entities;
using GuiandoSupplier.Domain.Interfaces.Repositories;
using GuiandoSupplier.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuiandoSupplier.Service.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly IBaseRepository<TEntity> repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public virtual async Task<TEntity> Add(TEntity obj)
        {
            await repository.Add(obj);

            return obj;
        }

        public virtual async Task Delete(long id)
        {
            await repository.Delete(id);
        }

        public virtual Task<List<TEntity>> Get()
        {
            return repository.Get();
        }

        public virtual Task<TEntity> Get(long id)
        {
            return repository.Get(id);
        }

        public virtual TEntity GetAsnotrack(long id)
        {
            return repository.GetAsNoTrackingId(id);
        }

        public virtual async Task<TEntity> Update(TEntity obj)
        {
            await repository.Update(obj);
            return obj;
        }
    }
}
