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

            Supplier supplier = GetSupplier();

            context.Supplier.Add(supplier);
            context.SaveChanges();
        }

        private static Supplier GetSupplier()
        {
            return new Supplier
            {
                Name = "Erik Sena Corp Ltda",
                LinkLogin = "https://www.linkedin.com/in/erik-sena-da-silva/",
                LogoUrl = "/logo/eriksena.png",
                Historic = true
            };
        }
    }
}
