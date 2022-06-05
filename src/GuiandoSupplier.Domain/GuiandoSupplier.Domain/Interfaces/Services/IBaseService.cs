using GuiandoSupplier.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuiandoSupplier.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity, new()
    {
        Task<TEntity> Add(TEntity obj);
        Task<List<TEntity>> Get();
        Task<TEntity> Get(long id);
        //TEntity GetAsnotrack(long id);
        Task<TEntity> Update(TEntity obj);
        Task Delete(long id);
        
    }
}
