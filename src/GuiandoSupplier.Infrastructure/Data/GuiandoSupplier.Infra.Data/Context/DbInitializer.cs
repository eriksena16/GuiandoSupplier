using GuiandoSupplier.Domain.Entities;
using System.Linq;

namespace GuiandoSupplier.Infra.Data.Context
{
    public class DbInitializer
    {
        public static void Initialize(GuiandoContext context)
        {
            context.Database.EnsureCreated();

            if (context.Supplier.Any())
            {
                return;
            }

            Supplier supplier = new Supplier
            {
                Nome = "Erik Sena Corp Ltda",
                CNPJ = "16.041.995/0001-05",
                LinkLogin = "https://www.linkedin.com/in/erik-sena-da-silva/",
                LogoUrl = "/logo/eriksena.png",
                Historico = true
            };

            context.Supplier.Add(supplier);
            context.SaveChanges();
        }
    }
}
