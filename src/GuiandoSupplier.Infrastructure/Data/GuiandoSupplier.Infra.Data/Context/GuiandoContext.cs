using GuiandoSupplier.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GuiandoSupplier.Infra.Data.Context
{
    public class GuiandoContext : DbContext
    {
        public GuiandoContext( DbContextOptions<GuiandoContext> options) : base(options)
        {

        }
        public DbSet<Supplier> Supplier { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GuiandoContext).Assembly);

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(decimal))))
                property.SetColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);
        }
    }
}