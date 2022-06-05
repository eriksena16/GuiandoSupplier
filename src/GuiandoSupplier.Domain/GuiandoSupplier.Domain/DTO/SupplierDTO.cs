namespace GuiandoSupplier.Domain.Entities
{
    public class SupplierDTO : BaseEntity
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string LinkLogin { get; set; }
        public bool Historico { get; set; }
        public string LogoUrl { get; set; }
    }
}
