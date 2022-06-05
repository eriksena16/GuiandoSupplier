using GuiandoSupplier.Domain.Entities;
using GuiandoSupplier.Domain.Interfaces.Repositories;
using GuiandoSupplier.Infra.Data.Context;

namespace GuiandoSupplier.Service.Repositories
{
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(GuiandoContext context) : base(context) { }
    }
}
