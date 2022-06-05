using GuiandoSupplier.Domain.Interfaces.Repositories;
using GuiandoSupplier.Domain.Interfaces.Services;
using GuiandoSupplier.Infra.Data.Context;
using GuiandoSupplier.Infra.Data.Repository;
using GuiandoSupplier.Service.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GuiandoSupplier.Infra.IoC
{
    public static class GuiandoSupllierLocator
    {
        public static void ConfigureGuiandoService(this IServiceCollection services)
        {

            #region Repositories
            services.AddScoped<DbContext, GuiandoContext>();
            //services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion Repositories

            #region Services
            services.AddScoped<ISupplierService, SupplierService>();
            #endregion Services
        }
    }
}
