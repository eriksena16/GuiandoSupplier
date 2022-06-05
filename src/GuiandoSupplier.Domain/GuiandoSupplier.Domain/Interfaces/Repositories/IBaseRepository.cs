using GuiandoSupplier.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GuiandoSupplier.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task Add(TEntity obj);
        Task<TEntity> Get(long id);
        TEntity GetAsNoTrackingId(long id);
        Task<List<TEntity>> Get();
        Task Update(TEntity obj);
        Task Delete(long id);
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
       
    }
}
