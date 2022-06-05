using System.ComponentModel.DataAnnotations;

namespace GuiandoSupplier.Domain.Entities
{
    public class SupplierDTO : BaseEntity
    {
        [Display(Name ="Empresa")]
        public string Name { get; set; }
        [Display(Name = "Link para Login")]
        public string LinkLogin { get; set; }
        [Display(Name = "Historico")]
        public bool Historic { get; set; }
        [Display(Name = "Logo")]
        public string LogoUrl { get; set; }
        public Verticals Verticals { get; set; }
        [Display(Name = "Vertical")]
        public string VerticalsName { get; set; }
    }
}
