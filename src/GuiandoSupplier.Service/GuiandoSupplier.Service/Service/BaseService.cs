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

        public async Task<TEntity> Add(TEntity obj)
        {
            await repository.Add(obj);

            return obj;
        }

        public async Task Delete(long id)
        {
            await repository.Delete(id);
        }

        public Task<List<TEntity>> Get()
        {
            return repository.Get();
        }

        public Task<TEntity> Get(long id)
        {
            return repository.Get(id);
        }

     public async Task<TEntity> Update(TEntity obj)
        {
            await repository.Update(obj);
            return obj;
        }
    }
}
