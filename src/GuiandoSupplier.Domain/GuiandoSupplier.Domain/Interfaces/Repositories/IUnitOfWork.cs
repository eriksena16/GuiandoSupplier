using System.Threading.Tasks;

namespace GuiandoSupplier.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
