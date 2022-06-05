namespace GuiandoSupplier.Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }
        public string LinkLogin { get; set; }
        public bool Historic { get; set; }
        public string LogoUrl { get; set; }
        public Verticals Verticals { get; set; }
    }
}
