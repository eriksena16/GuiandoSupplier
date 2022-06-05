using GuiandoSupplier.Domain.Interfaces.Repositories;
using GuiandoSupplier.Infra.Data.Context;
using System.Threading.Tasks;

namespace GuiandoSupplier.Infra.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GuiandoContext _context;
        public UnitOfWork(GuiandoContext context)
        {
            _context = context;
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
