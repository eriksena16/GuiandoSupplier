using GuiandoSupplier.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GuiandoSupplier.Infra.Data.Mapping
{
    public class SupplierMapping : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
               .IsRequired()
               .HasColumnType("varchar(200)");

            builder.Property(p => p.LogoUrl)
               .IsRequired()
               .HasColumnType("varchar(200)");

            builder.Property(p => p.LinkLogin)
               .IsRequired()
               .HasColumnType("varchar(200)");

        }
    }
}
